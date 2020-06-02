using System.Collections.Generic;
using BrewerySearch.Models;

namespace BrewerySearch.Data
{
    public interface IBreweryRepo
    {
        bool SaveChanges();
        IEnumerable<Brewery> GetAllBreweries();
        Brewery GetBreweryById(int id);
        void CreateBrewery(Brewery brw);
        void UpdateBrewery(Brewery brw);
        void DeleteBrewery(Brewery brw);
    }
}
