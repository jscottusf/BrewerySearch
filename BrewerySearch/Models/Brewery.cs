using System.ComponentModel.DataAnnotations;

namespace BrewerySearch.Models
{
    public class Brewery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BreweryName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string Url { get; set; }
    }
}
