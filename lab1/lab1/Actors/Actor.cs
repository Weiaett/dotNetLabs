using lab1.Products;
using System;

namespace lab1
{
    public abstract class Actor : IActor
    {
        public string Name { get; }

        protected Actor(string name)
        {
            Name = name;
        }

        //private decimal Reward { set; get; }

        protected static Random Random = new Random();

        public abstract void MakeBook(IBook book);

        //public void PresentBook(IBook book)
        //{
        //    if (book.IsSuccessfull)
        //    {
        //        Reward = Random.Next(50000, 500000);
        //        Console.Write($"Презентация проведена успешно, получен гонорар {Reward}");
        //    }
        //}
    }
}
