using System;
using lab1.Products;

namespace lab1.Actors
{
    public class Writer : Actor
    {
        public Writer(string name) : base(name)
        {
        }

        public override void MakeBook(IBook book)
        {
            book.Text.PagesNum += (uint)Random.Next(5, 100);
            Console.WriteLine($"Всего написано: {book.Text.PagesNum} страниц");
        }
    }
}
