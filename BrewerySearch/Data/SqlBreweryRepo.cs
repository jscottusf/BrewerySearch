using System;
using System.Collections.Generic;
using System.Linq;
using BrewerySearch.Models;

namespace BrewerySearch.Data
{
    public class SqlBreweryRepo : IBreweryRepo
    {
        private readonly BreweryContext _context;

        public SqlBreweryRepo(BreweryContext context)
        {
            _context = context;
        }

        public void CreateBrewery(Brewery brw)
        {
            if (brw == null)
            {
                throw new ArgumentNullException(nameof(brw));
            }

            _context.Breweries.Add(brw);
        }

        public void DeleteBrewery(Brewery brw)
        {
            if (brw == null)
            {
                throw new ArgumentNullException(nameof(brw));
            }
            _context.Breweries.Remove(brw);
        }

        public IEnumerable<Brewery> GetAllBreweries()
        {
            return _context.Breweries.ToList();
        }

        public Brewery GetBreweryById(int id)
        {
            return _context.Breweries.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateBrewery(Brewery brw)
        {
            //Nothing
        }
    }
}