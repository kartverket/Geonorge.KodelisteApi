using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using www.opengis.net;

namespace Geonorge.Kodeliste.Controllers
{
    [ApiController]
    public class DatasetController : ControllerBase
    {
        private readonly ILogger<DatasetController> _logger;
        private static readonly HttpClient HttpClient = new HttpClient();

        public DatasetController(ILogger<DatasetController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("datasets")]
        public IEnumerable<Dataset> Get()
        {
            GeoNorgeAPI.GeoNorge _geoNorge = new GeoNorgeAPI.GeoNorge("", "", "http://www.geonorge.no/geonetwork/srv/nor/csw-dataset");
            var filters = new object[]
            {
                    new PropertyIsLikeType
                        {
                            escapeChar = "\\",
                            singleChar = "_",
                            wildCard = "%",
                            PropertyName = new PropertyNameType {Text = new[] {"anyText"}},
                            Literal = new LiteralType {Text = new[] {"objektkatalog.geonorge.no"}}
                        }
            };

            var filterNames = new ItemsChoiceType23[]
            {
                        ItemsChoiceType23.PropertyIsLike,
            };

            List<Dataset> datasetList = new List<Dataset>();

            var res = _geoNorge.SearchWithFilters(filters, filterNames, 1, 1000, false);
            for (int s = 0; s < res.Items.Length; s++)
            {
                string title = ((www.opengis.net.DCMIRecordType)(res.Items[s])).Items[2].Text[0];
                string type = ((www.opengis.net.DCMIRecordType)(res.Items[s])).Items[3].Text[0];
                if(type == "dataset")
                    datasetList.Add(new Dataset { Title = title });
            }

            datasetList = datasetList.OrderBy(o => o.Title).ToList();

            return datasetList;
        }

        [HttpGet]
        [Route("dataset/{title}")]
        public Dataset GetDatasetCodeLists(string title)
        {
            GeoNorgeAPI.GeoNorge _geoNorge = new GeoNorgeAPI.GeoNorge();

            Dataset dataset = new Dataset();
            List<DatasetVersion> datasetsVersions = new List<DatasetVersion>();

            var res = _geoNorge.SearchIso(title);

            if (res.numberOfRecordsReturned == "0")
                return null;

            for (int s = 0; s < res.Items.Length; s++)
            {
                var data = new GeoNorgeAPI.SimpleMetadata(res.Items[s] as MD_Metadata_Type);
                if (data != null && data.Title == title && !string.IsNullOrEmpty(data.ProductSpecificationUrl))
                {
                    dataset.Title = data.Title;
                    var prodSpecUrl = data.ProductSpecificationUrl;

                    if (!string.IsNullOrEmpty(prodSpecUrl))
                    {
                        HttpResponseMessage response = HttpClient.GetAsync(prodSpecUrl + ".json").Result;
                        response.EnsureSuccessStatusCode();
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        var jsonObject = JsonNode.Parse(responseBody);

                        string versionName = jsonObject["versionName"]?.ToString();
                        dataset.VersionName = versionName;
                        string status = jsonObject["status"].ToString();
                        dataset.Status = status;

                        var GMLApplicationSchema = jsonObject["GMLApplicationSchema"]?.ToString();
                        if (GMLApplicationSchema != null) 
                        {
                            HttpResponseMessage responseGml = HttpClient.GetAsync(GMLApplicationSchema).Result;
                            responseGml.EnsureSuccessStatusCode();
                            string responseGmlBody = responseGml.Content.ReadAsStringAsync().Result;

                            GetCodeList(dataset, responseGmlBody);
                        }

                        var versions = jsonObject["versions"]?.AsArray();

                        if(versions != null && versions.Count > 0)
                            dataset.Versions = new List<DatasetVersion>();

                        if(versions != null) 
                        { 
                            foreach (var version in versions)
                            {
                                versionName = version["versionName"]?.ToString();
                                var label = version["label"].ToString();
                                DatasetVersion datasetVersion = new DatasetVersion();
                                datasetVersion.Title = label;
                                datasetVersion.VersionName = versionName;
                                status = version["status"].ToString();
                                datasetVersion.Status = status;

                                GMLApplicationSchema = version["GMLApplicationSchema"]?.ToString();
                                if(GMLApplicationSchema != null) 
                                {
                                    HttpResponseMessage responseGml = HttpClient.GetAsync(GMLApplicationSchema).Result;
                                    responseGml.EnsureSuccessStatusCode();
                                    string responseGmlBody = responseGml.Content.ReadAsStringAsync().Result;

                                    GetCodeList(datasetVersion, responseGmlBody);
                                }

                                dataset.Versions.Add(datasetVersion);
                            }
                        }
                    }

                }
            }



            return dataset;
        }

        [HttpGet]
        [Route("url/{url}/{format}")]
        public IActionResult GetUrlCodelist(string url, string format = "json") 
        {
            HttpResponseMessage response = HttpClient.GetAsync(HttpUtility.UrlDecode(url) + "." + format).Result;
            response.EnsureSuccessStatusCode();

            string contentType = GetContentType(format);

            return File(response.Content.ReadAsStream(), contentType);
        }

        private string GetContentType(string extension)
        {
            string contentType = "text/plain";

            if (extension == "csv")
            {
                contentType = "text/csv";
            }
            else if (extension == "gml")
            {
                contentType = "application/gml+xml";
            }
            else if (extension == "rdf")
            {
                contentType = "application/gml+xml";
            }
            else if (extension == "rss")
            {
                contentType= "application/rss+xml";
            }
            else if (extension == "atom")
            {
                contentType = "application/atom+xml";
            }
            else if (extension == "xml")
            {
                contentType = "application/xml";
            }
            else if (extension == "skos")
            {
                contentType = "application/xml+rdf";
            }
            else if (extension == "json")
            {
                contentType = "application/json";
            }

            return contentType;
        }

        private void GetCodeList(DatasetVersion datasetVersion, string gmlApplicationSchema)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("gml", "http://www.opengis.net/gml/3.2");
            nsmgr.AddNamespace("app", "http://www.interactive-instruments.de/ShapeChange/AppInfo");

            xmlDoc.LoadXml(gmlApplicationSchema);

            var xappinfos = xmlDoc.GetElementsByTagName("appinfo");

            if (xappinfos != null && xappinfos.Count > 0)
                datasetVersion.CodeLists = new List<CodeList>();

            foreach (XmlNode xappinfo in xappinfos)
            {
                var codeList = xappinfo.SelectSingleNode("gml:defaultCodeSpace", nsmgr)?.InnerText;
                if (codeList != null)
                {
                    var name = xappinfo.SelectSingleNode("app:taggedValue", nsmgr)?.InnerText;
                    if (name != null)
                    {
                        var contains = datasetVersion.CodeLists.Where(c => c.Url.Contains(codeList));
                        if (!contains.Any())
                            datasetVersion.CodeLists.Add(new CodeList { Name = name, Url = codeList });
                    }
                }

            }
            if (datasetVersion.CodeLists != null && datasetVersion.CodeLists.Count == 0)
                datasetVersion.CodeLists = null;
            else if (datasetVersion.CodeLists != null)
            datasetVersion.CodeLists = datasetVersion.CodeLists.OrderBy(o => o.Name).ToList();
        }

        private static void GetCodeList(Dataset dataset, string gmlApplicationSchema)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("gml", "http://www.opengis.net/gml/3.2");
            nsmgr.AddNamespace("app", "http://www.interactive-instruments.de/ShapeChange/AppInfo");

            xmlDoc.LoadXml(gmlApplicationSchema);

            var xappinfos = xmlDoc.GetElementsByTagName("appinfo");

            if (xappinfos != null && xappinfos.Count > 0)
                dataset.CodeLists = new List<CodeList>();

            foreach (XmlNode xappinfo in xappinfos)
            {
                var codeList = xappinfo.SelectSingleNode("gml:defaultCodeSpace", nsmgr)?.InnerText;
                if (codeList != null)
                {
                    var name = xappinfo.SelectSingleNode("app:taggedValue", nsmgr)?.InnerText;
                    if (name != null)
                    {
                        var contains = dataset.CodeLists.Where(c => c.Url.Contains(codeList));
                        if (!contains.Any())
                            dataset.CodeLists.Add(new CodeList { Name = name, Url = codeList });
                    }
                }

            }
            if (dataset.CodeLists != null && dataset.CodeLists.Count == 0)
                dataset.CodeLists = null;
            else if(dataset.CodeLists != null && dataset.CodeLists.Count > 0)
                dataset.CodeLists = dataset.CodeLists.OrderBy(o => o.Name).ToList();
        }
    }
}