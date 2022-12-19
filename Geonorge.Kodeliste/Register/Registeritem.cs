using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace Kartverket.Register.Models.Api
{
    [DataContractAttribute]
    public class Registeritem
    {


        // RegisterItem
        [DataMemberAttribute]
        public string id { get; set; }
        /// <summary>
        /// Name for list item
        /// </summary>
        /// <example>Hopen</example>
        [DataMemberAttribute]
        public string label { get; set; }
        [DataMemberAttribute]
        public string lang { get; set; }
        [DataMemberAttribute]
        public string itemclass { get; set; }
        [DataMemberAttribute]
        public Guid uuid { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string status { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string description { get; set; }
        [DataMemberAttribute]
        public string seoname { get; set; }
        [DataMemberAttribute]
        public string owner { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string versionName { get; set; }
        [DataMemberAttribute]
        public int versionNumber { get; set; }
        [DataMemberAttribute]
        [XmlIgnore]
        public ICollection<Registeritem> versions { get; set; }
        public bool ShouldSerializeversions()
        {
            return versions != null && versions.Count() > 0;
        }
        [DataMemberAttribute]
        public DateTime lastUpdated { get; set; }
        [DataMemberAttribute]
        public DateTime dateSubmitted { get; set; }
        [DataMemberAttribute]
        public DateTime dateAccepted { get; set; }
        public bool ShouldSerializedateAccepted()
        {
            return dateAccepted != null && dateAccepted != DefaultDate;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ApplicationSchema { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UmlModelTreeStructureLink { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GMLApplicationSchema { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CartographyFile { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? draftDate { get; set; }
        public bool ShouldSerializedraftDate()
        {
            return draftDate != null && draftDate != DefaultDate;
        }

        // Organization
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string number { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string OrganizationNumber { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LogoFilename { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string LogoLargeFilename { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ContactPerson { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Email { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NorgeDigitaltMember { get; set; }
        public bool ShouldSerializeNorgeDigitaltMember()
        {
            return NorgeDigitaltMember.HasValue;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? AgreementYear { get; set; }
        public bool ShouldSerializeAgreementYear()
        {
            return AgreementYear.HasValue;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AgreementDocumentUrl { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PriceFormDocument { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ShortName { get; set; }
        public string OrganizationType { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MunicipalityCode { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GeographicCenterX { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GeographicCenterY { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BoundingBoxNorth { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BoundingBoxSouth { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BoundingBoxEast { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BoundingBoxWest { get; set; }


        // EPSG
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string documentreference { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string epsgcode { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string sosiReferencesystem { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string inspireRequirement { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string nationalRequirement { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string nationalSeasRequirement { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string verticalReferenceSystem { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string horizontalReferenceSystem { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dimension { get; set; }

        // CodelistValue
        /// <summary>
        /// Code value register item
        /// </summary>
        /// <example>2131</example>
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string codevalue { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string broader { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> narrower { get; set; }
        public bool ShouldSerializenarrower()
        {
            return narrower != null && narrower.Count() > 0;
        }

        [DataMemberAttribute]
        [XmlIgnore]
        public List<NarrowerDetails> narrowerdetails { get; set; }
        public bool ShouldSerializenarrowerdetails()
        {
            return narrowerdetails != null && narrowerdetails.Count() > 0;
        }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ValidFrom { get; set; }
        public bool ShouldSerializeValidFrom()
        {
            return ValidFrom.HasValue;
        }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ValidTo { get; set; }
        public bool ShouldSerializeValidTo()
        {
            return ValidTo.HasValue;
        }

        //NameSpace
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string serviceUrl { get; set; }

        // Dataset
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string theme { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? dokStatusDateAccepted { get; set; }
        public bool ShouldSerializedokStatusDateAccepted()
        {
            return dokStatusDateAccepted.HasValue;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? Kandidatdato { get; set; }
        public bool ShouldSerializeKandidatdato()
        {
            return Kandidatdato.HasValue;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryMetadataStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryProductSheetStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryPresentationRulesStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryProductSpecificationStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryWmsStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryWfsStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliverySosiRequirementsStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryDistributionStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryGmlRequirementsStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string dokDeliveryAtomFeedStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? restricted { get; set; }
        public bool ShouldSerializerestricted()
        {
            return restricted.HasValue;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DatasetType { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UuidMetadata { get; set; }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Suitability Suitability { get; set; }


        //MunicipalDataset
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ConfirmedDok { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Coverage { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string NoteMunicipal { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Measure { get; set; }

        // Alert
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MetadataUrl { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? AlertDate { get; set; }
        public bool ShouldSerializeAlertDate()
        {
            return AlertDate != null && AlertDate != DefaultDate;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AlertType { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ServiceType { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? EffectiveDate { get; set; }
        public bool ShouldSerializeEffectiveDate()
        {
            return EffectiveDate != null && EffectiveDate != DefaultDate;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Note { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ServiceUuid { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AlertCategory { get; set; }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Departements { get; set; }
        public bool ShouldSerializeDepartement()
        {
            return Departements != null && Departements.Count > 0;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Station { get; set; }
        public bool ShouldSerializeStation()
        {
            return !string.IsNullOrEmpty(Station);
        }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StationName { get; set; }
        public bool ShouldSerializeStationName()
        {
            return !string.IsNullOrEmpty(StationName);
        }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StationType { get; set; }
        public bool ShouldSerializeStationType()
        {
            return !string.IsNullOrEmpty(StationType);
        }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Tags { get; set; }
        public bool ShouldSerializeTags()
        {
            return Tags != null && Tags.Count > 0;
        }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? DateResolved { get; set; }
        public bool ShouldSerializeDateResolved()
        {
            return DateResolved.HasValue;
        }

        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Summary { get; set; }
        public bool ShouldSerializeSummary()
        {
            return !string.IsNullOrEmpty(Summary);
        }

        // InspireDataset
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MetadataStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string MetadataServiceStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DistributionStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string WmsStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string WfsStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AtomFeedStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string WfsOrAtomStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HarmonizedDataStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SpatialDataServiceStatus { get; set; }

        // InspireDataService
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string InspireDataType { get; set; }
        public string MetadataInSearchServiceStatus { get; set; }
        public string ServiceStatus { get; set; }
        public int? Requests { get; set; }
        public bool ShouldSerializeRequests()
        {
            return Requests.HasValue;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string InspireTheme { get; set; }
        public bool? NetworkService { get; set; }
        public bool ShouldSerializeNetworkService()
        {
            return NetworkService.HasValue;
        }
        public bool? Sds { get; set; }
        public bool ShouldSerializeSds()
        {
            return Sds.HasValue;
        }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string InspireStatus { get; set; }

        // GeodatalovDataset
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CommonStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GmlStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SosiStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ProductspesificationStatus { get; set; }

        //Mareano
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FindableStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string AccesibleStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string InteroperableStatus { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ReUsableStatus { get; set; }

        [IgnoreDataMember]
        [XmlIgnore]
        public DateTime DefaultDate { get; set; } = new DateTime(1, 1, 1, 0, 0, 0) ;
        public string ProductSheetStatus { get; set; }
        public string PresentationRulesStatus { get; set; }
        [DataMemberAttribute]
        public List<NameSpaceDatasetUrl> NameSpaceDatasetUrls { get; set; }
        public bool ShouldSerializeNameSpaceDatasetUrls()
        {
            return NameSpaceDatasetUrls != null && NameSpaceDatasetUrls.Count() > 0;
        }
    }

    public class NarrowerDetails {
        public string id { get; set; }
        public string label { get; set; }
        public string codevalue { get; set; }
        public List<NarrowerDetails> narrowerdetails { get; set; }
    }

    public class Suitability
    {
        public int RegionalPlan { get; set; }
        public string RegionalPlanNote { get; set; }

        public int MunicipalSocialPlan { get; set; }
        public string MunicipalSocialPlanNote { get; set; }

        public int MunicipalLandUseElementPlan { get; set; }
        public string MunicipalLandUseElementPlanNote { get; set; }

        public int ZoningPlan { get; set; }
        public string ZoningPlanNote { get; set; }

        public int BuildingMatter { get; set; }
        public string BuildingMatterNote { get; set; }

        public int ImpactAssessmentPlanningBuildingAct { get; set; }
        public string ImpactAssessmentPlanningBuildingActNote { get; set; }

        public int RiskVulnerabilityAnalysisPlanningBuildingAct { get; set; }
        public string RiskVulnerabilityAnalysisPlanningBuildingActNote { get; set; }
    }

    public class NameSpaceDatasetUrl 
    {
        public string DatasettId { get; set; }
        public string RedirectUrl { get; set; }
    }
}