using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Products
{
    public class Illustration : Product
    {

        public uint Page { get; }

        public Illustration(uint page)
        {
            Page = page;
        }
    }
}
