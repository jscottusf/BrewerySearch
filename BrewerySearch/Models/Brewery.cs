using System.ComponentModel.DataAnnotations;

namespace BrewerySearch.Models
{
    public class Brewery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BreweryName { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
    }
}
