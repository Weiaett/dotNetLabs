using lab3.Products;
using lab3.Wages;
using lab4.Logger;
using System;

namespace lab3.Actors
{
    /// <summary>
    /// Издатель
    /// </summary>
    public class Publisher<T> : Actor<T> where T : ISalary
    {
        public override event EventHandler<DoWorkArgs> OnDoWork;

        public Publisher(string name, T salary) : base(name, salary)
        {
        }
        public Publisher(string name) : base(name)
        {
        }
        public override void Introduce()
        {
            Console.WriteLine($"Издатель {Name}");
            Salary.Print();
        }

        /// <summary>
        /// Издатель выпускает книгу
        /// </summary>
        /// <param name="book"></param>
        public override void MakeBook(IBook book)
        {
            uint year = (uint) Random.Next(1700, 2200);
            book.PublicationYear = year;
            OnDoWork(this, new DoWorkArgs() { Payload = year });
            //Console.WriteLine($"Год публикации: {book.PublicationYear}");
        }
    }
}
