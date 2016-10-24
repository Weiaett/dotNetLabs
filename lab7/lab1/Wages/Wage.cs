using System;

namespace lab3.Wages
{
    [Serializable]
    public class Wage : Salary, IWage
    {
        private Wage() { }
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
