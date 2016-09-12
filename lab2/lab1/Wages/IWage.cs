using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Wages
{
    /// <summary>
    /// Интерфейс периодичной заработной платы
    /// </summary>
    public interface IWage : ISalary
    {
        /// <summary>
        /// Период получения заработной платы
        /// </summary>
        int PeriodInDays { get; set; }
    }
}
