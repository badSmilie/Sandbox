using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VierGewinntCore
{
    public class PlatzFactory : IPlatzFactory
    {
        public IPlatz Erstelle(int spaltenIndex, int zeilenIndex)
        {
            return new Platz(spaltenIndex, zeilenIndex); 
        }
    }
}
