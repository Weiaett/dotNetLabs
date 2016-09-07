using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Factories
{
    public class OrdinarBookFactory : BaseBookFactory
    {
        protected override uint CostPrice { get; }

        public OrdinarBookFactory()
        {
            CostPrice = 150;
        }
    }
}
