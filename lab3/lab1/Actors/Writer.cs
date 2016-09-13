using System;
using lab3.Products;
using lab3.Wages;

namespace lab3.Actors
{
    /// <summary>
    /// Писатель
    /// </summary>
    public class Writer<T> : Actor<T> where T : ISalary
    {
        public Writer(string name, T salary) : base(name, salary)
        {
        }
        public Writer(string name) : base(name)
        {
        }
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
            book.Text.PagesNum += (uint)Random.Next(5, 100);
            //Console.WriteLine($"Всего написано: {book.Text.PagesNum} страниц");
        }
    }
}
