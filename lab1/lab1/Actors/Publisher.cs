using lab1.Products;
using System;

namespace lab1.Actors
{
    public class Publisher : Actor
    {
        public Publisher(string name) : base(name)
        {
        }

        public override void MakeBook(IBook book)
        {
            book.PublicationDate = (uint) DateTime.Now.Year;
            Console.WriteLine($"Год публикации: {book.PublicationDate}");
        }
    }
}
