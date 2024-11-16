using Pr3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr3
{
    public class Helper
    {
        private static РесторанEntities3 _context;
        public static РесторанEntities3 GetContext()
        {
        if (_context == null)
            {
                _context = new РесторанEntities3();
            }
        return _context;
        }
    }
}
