using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makani.Models
{
    public class MakaniRepository
    {
        private MakaniContext _context;

        public MakaniRepository(MakaniContext context)
        {
            _context = context;
        }

        public IEnumerable<Package> GetAllPackages()
        {
            return _context.Packages.ToList();
        }

        public void AddPackage(Package newPackage)
        {
            _context.Add(newPackage);
        }

        public Package GetPackageByName(string packageName)
        {
            return _context.Packages.Include(c => c.Cities)
                .Where(p => p.CommercialName == packageName)
                .FirstOrDefault();
        }

        public void AddCity(City newCity)
        {
            _context.Cities.Add(newCity);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
