using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Web;

namespace Kartverket.Register.Models.Api
{
    [DataContractAttribute]
    public class Register
    {
        [DataMemberAttribute]
        public Result ContainedItemsResult { get; set; }

        /// <summary>
        /// id/url for code list
        /// </summary>
        /// <example>https://register.geonorge.no/sosi-kodelister/kommunenummer-alle</example>
        [DataMemberAttribute]
        public string id { get; set; }
        /// <summary>
        /// Name for code list
        /// </summary>
        /// <example>Kumunenummer alle</example>
        [DataMemberAttribute]
        public string label { get; set; }
        [DataMemberAttribute]
        public string lang { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string contentsummary { get; set; }
        [DataMemberAttribute]
        public string owner { get; set; }
        [DataMemberAttribute]
        public string status { get; set; }
        [DataMemberAttribute]
        public string manager { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string controlbody { get; set; }
        [DataMemberAttribute]
        public string containedItemClass { get; set; }
        [DataMemberAttribute]
        public Guid uuid { get; set; }
        [DataMemberAttribute]
        public List<Registeritem> containeditems { get; set; }
        [DataMemberAttribute]
        public List<Register> containedSubRegisters { get; set; }
        [DataMemberAttribute]
        public DateTime lastUpdated { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string targetNamespace { get; set; }
        [DataMemberAttribute]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SelectedDOKMunicipality { get; set; }
        public bool ShouldSerializeSelectedDOKMunicipality()
        {
            return !string.IsNullOrEmpty(SelectedDOKMunicipality);
        }

    }
}