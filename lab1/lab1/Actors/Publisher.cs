using lab1.Products;
using System;

namespace lab1.Actors
{
    /// <summary>
    /// Издатель
    /// </summary>
    public class Publisher : Actor
    {
        public Publisher(string name) : base(name)
        {
        }

        /// <summary>
        /// Издатель выпускает книгу
        /// </summary>
        /// <param name="book"></param>
        public override void MakeBook(IBook book)
        {
            book.PublicationYear = (uint) DateTime.Now.Year;
            Console.WriteLine($"Год публикации: {book.PublicationYear}");
        }
    }
}
