using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Actors
{
    public interface IPerson
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        string Name { get; }


        /// <summary>
        /// Представиться
        /// </summary>
        void Introduce();
    }
}
