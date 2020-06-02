using System.ComponentModel.DataAnnotations;

namespace BrewerySearch.Dtos
{
    public class BreweryUpdateDto
    {
        [Required]
        public string BreweryName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Url { get; set; }
    }
}