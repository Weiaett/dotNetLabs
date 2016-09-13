using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Wages
{
    /// <summary>
    /// Интерфейс заработка
    /// </summary>
    public interface ISalary
    {
        /// <summary>
        /// Сумма заработка
        /// </summary>
        int Sum { set; get; }

        void Print();
    }
}
