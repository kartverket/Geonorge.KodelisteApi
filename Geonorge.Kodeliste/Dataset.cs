using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Geonorge.Kodeliste
{
    public class Dataset
    {
        /// <summary>
        /// Dataset/metadata tittel
        /// </summary>
        /// <example>FKB-Bygning</example>
        [Required]
        public string Title { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string VersionName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Status { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CodeList> CodeLists { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<DatasetVersion> Versions { get; set; }
    }
}