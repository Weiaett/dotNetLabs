using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Wages
{
    [Serializable]
    public abstract class Salary : ISalary
    {
        protected Salary() { }
        public int Sum { get; set; }

        public Salary(int sum)
        {
            Sum = sum;
        }

        public abstract void Print();
    }
}
