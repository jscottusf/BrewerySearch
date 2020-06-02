using BrewerySearch.Models;
using Microsoft.EntityFrameworkCore;

namespace BrewerySearch.Data
{
    public class BreweryContext : DbContext
    {
        public BreweryContext(DbContextOptions<BreweryContext> opt) : base(opt)
        {

        }

        public DbSet<Brewery> Breweries { get; set; }
    }
}