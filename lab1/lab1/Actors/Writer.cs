using System;
using lab1.Products;

namespace lab1.Actors
{
    /// <summary>
    /// Писатель
    /// </summary>
    public class Writer : Actor
    {
        public Writer(string name) : base(name)
        {
        }

        /// <summary>
        /// Писатель работает над книгой, увеличивая число страниц
        /// </summary>
        /// <param name="book">Книга, над которой идет работа</param>
        public override void MakeBook(IBook book)
        {
            book.Text.PagesNum += (uint)Random.Next(5, 100);
            Console.WriteLine($"Всего написано: {book.Text.PagesNum} страниц");
        }
    }
}
