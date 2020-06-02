using System.ComponentModel.DataAnnotations;

namespace BrewerySearch.Dtos
{
    public class BreweryCreateDto
    {
        [Required]
        public string BreweryName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
