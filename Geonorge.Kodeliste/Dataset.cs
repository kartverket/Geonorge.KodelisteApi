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
        /// <summary>
        /// Versjon av datamodellen
        /// </summary>
        /// <example>Versjon 5.0</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string VersionName { get; set; }
        /// <summary>
        /// Status p� datamodellen
        /// </summary>
        /// <example>SOSI godkjent</example>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Status { get; set; }
        /// <summary>
        /// Kodelister som benyttes i datamodellen
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CodeList> CodeLists { get; set; }
        /// <summary>
        /// Ulike versjoner av datamodellen
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<DatasetVersion> Versions { get; set; }
    }
}