using System.ComponentModel.DataAnnotations;

namespace Geonorge.Kodeliste
{
    public class CodeList
    {
        /// <summary>
        /// Navn på kodeliste
        /// </summary>
        /// <example>KOMM</example>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Url til kodeliste-verdier
        /// </summary>
        /// <example>https://register.geonorge.no/sosi-kodelister/kommunenummer-alle</example>
        [Required]
        public string Url { get; set; }
    }
}
