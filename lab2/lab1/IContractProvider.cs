using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    /// <summary>
    /// Интерфейс представления контракта
    /// </summary>
    /// <typeparam name="T">Тип обладателя контракта</typeparam>
    public interface IContractProvider<in T>
    {
        void PrintContract(T person);
    }
}
