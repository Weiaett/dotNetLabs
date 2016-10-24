using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Logger
{
    /// <summary>
    /// Аргументы события OnDoWork
    /// </summary>
    public class DoWorkArgs : EventArgs
    {
        //public ProductType Product { get; set; }
        public uint Payload { get; set; }
    }
}
