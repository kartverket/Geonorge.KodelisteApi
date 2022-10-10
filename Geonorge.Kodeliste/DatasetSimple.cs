using System.ComponentModel.DataAnnotations;

namespace Geonorge.Kodeliste
{
    public class DatasetSimple
    {
        /// <summary>
        /// Dataset/metadata tittel
        /// </summary>
        /// <example>FKB-Bygning</example>
        [Required]
        public string Title { get; set; }
    }
}
