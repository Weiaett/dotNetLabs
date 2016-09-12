using System;

namespace lab2.Wages
{
    public class Wage : Salary, IWage
    {
        public int PeriodInDays { get; set; }

        public Wage(int sum, int period) : base (sum)
        {
            PeriodInDays = period;
        }

        public override void Print()
        {
            Console.WriteLine($"Оклад: {Sum} руб. в {PeriodInDays} дней.");
        }
    }
}
