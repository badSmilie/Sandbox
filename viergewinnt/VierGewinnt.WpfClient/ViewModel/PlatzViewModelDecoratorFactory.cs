using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VierGewinntCore;

namespace VierGewinnt.WpfClient
{
    class PlatzViewModelDecoratorFactory : IPlatzFactory
    {
        private readonly IList<PlatzViewModelDecorator> platzviewmodeldecorator;
        public PlatzViewModelDecoratorFactory(IList<PlatzViewModelDecorator> platzviewdecorator)
        {
            platzviewmodeldecorator = platzviewdecorator;
        }
        public IPlatz Erstelle(int spaltenIndex, int zeilenIndex)
        {
            var platz = new PlatzViewModelDecorator(new PlatzFactory().Erstelle(spaltenIndex, zeilenIndex));
            platzviewmodeldecorator.Add(platz);
            return platz;
        }
    }
}
