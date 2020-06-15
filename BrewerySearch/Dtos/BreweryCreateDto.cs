using System.ComponentModel.DataAnnotations;

namespace BrewerySearch.Dtos
{
    public class BreweryCreateDto
    {
        [Required]
        public string BreweryName { get; set; }
        [Required]
        public string Logo { get; set; }
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
