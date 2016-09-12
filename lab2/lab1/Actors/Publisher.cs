using lab2.Products;
using lab2.Wages;
using System;

namespace lab2.Actors
{
    /// <summary>
    /// Издатель
    /// </summary>
    public class Publisher<T> : Actor<T> where T : ISalary
    {
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
            book.PublicationYear = (uint) DateTime.Now.Year;
            //Console.WriteLine($"Год публикации: {book.PublicationYear}");
        }
    }
}
