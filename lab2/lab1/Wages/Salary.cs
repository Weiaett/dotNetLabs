﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Wages
{
    public abstract class Salary : ISalary
    {
        public int Sum { get; set; }

        public Salary(int sum)
        {
            Sum = sum;
        }

        public abstract void Print();
    }
}
