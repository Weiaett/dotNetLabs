using System;
using lab1.Products;

namespace lab1.Actors
{
    /// <summary>
    /// Иллюстратор
    /// </summary>
    public class Illustrator : Actor
    {
        public Illustrator(string name) : base(name)
        {
        }

        /// <summary>
        /// Иллюстратор добавляет иллюстрации к уже написанным страницам книги
        /// </summary>
        /// <param name="book"></param>
        public override void MakeBook(IBook book)
        {
            Illustration illustration = new Illustration((uint)Random.Next(5, checked((int)book.Text.PagesNum)));
            book.Illustrations.Add(illustration);
            Console.WriteLine($"Иллюстрация на {illustration.Page} страницe");
        }
    }
}
