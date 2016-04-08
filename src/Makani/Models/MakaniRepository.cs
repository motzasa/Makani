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
    }
}
