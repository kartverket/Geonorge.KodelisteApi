using System.ComponentModel.DataAnnotations;

namespace Geonorge.Kodeliste
{
    public class CodeList
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
