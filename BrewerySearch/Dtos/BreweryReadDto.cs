using System;
namespace BrewerySearch.Dtos
{
    public class BreweryReadDto
    {
        public int Id { get; set; }
        public string BreweryName { get; set; }
        public string Logo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
    }
}
