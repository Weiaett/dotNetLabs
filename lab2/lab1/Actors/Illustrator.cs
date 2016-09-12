using System;
using lab2.Products;
using lab2.Wages;

namespace lab2.Actors
{
    /// <summary>
    /// Иллюстратор
    /// </summary>
    public class Illustrator<T> : Actor<T> where T : ISalary
    {
        public Illustrator(string name, T salary) : base(name, salary)
        {
        }
        public Illustrator(string name) : base(name)
        {
        }
        public override void Introduce()
        {
            Console.WriteLine($"Иллюстратор {Name}");
            Salary.Print();
        }

        /// <summary>
        /// Иллюстратор добавляет иллюстрации к уже написанным страницам книги
        /// </summary>
        /// <param name="book"></param>
        public override void MakeBook(IBook book)
        {
            Illustration illustration = new Illustration((uint)Random.Next(5, checked((int)book.Text.PagesNum)));
            book.Illustrations.Add(illustration);
            //Console.WriteLine($"Иллюстрация на {illustration.Page} страницe");
        }
    }
}
