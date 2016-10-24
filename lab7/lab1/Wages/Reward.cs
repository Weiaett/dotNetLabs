using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3.Wages
{
    [Serializable]
    public class Reward : Salary, IReward
    {
        private Reward() { }
        public Reward(int sum) : base(sum) { }

        public override void Print()
        {
            Console.WriteLine($"Гонорар: {Sum} руб.");
        }
    }
}
