using System;
using lab3.Products;
using lab3.Wages;
using lab4.Logger;

namespace lab3.Actors
{
    /// <summary>
    /// Писатель
    /// </summary>
    [Serializable]
    public class Writer<T> : Actor<T> where T : Salary
    {
        public override event EventHandler<DoWorkArgs> OnDoWork;

        public Writer(string name, T salary) : base(name, salary)
        {
        }
        public Writer(string name) : base(name)
        {
        }

        private Writer() { }
        
        public override void Introduce()
        {
            Console.WriteLine($"Писатель {Name}");
            Salary.Print();
        }

        /// <summary>
        /// Писатель работает над книгой, увеличивая число страниц
        /// </summary>
        /// <param name="book">Книга, над которой идет работа</param>
        public override void MakeBook(IBook book)
        {
            uint delta = (uint)Random.Next(5, 100);
            book.Text.PagesNum += delta;
            OnDoWork(this, new DoWorkArgs() { Payload = delta});
            //Console.WriteLine($"Всего написано: {book.Text.PagesNum} страниц");
        }
    }
}
