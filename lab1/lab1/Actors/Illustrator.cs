using System;
using lab1.Products;

namespace lab1.Actors
{
    public class Illustrator : Actor
    {
        public Illustrator(string name) : base(name)
        {
        }

        public override void MakeBook(IBook book)
        {
            Illustration illustration = new Illustration((uint)Random.Next(5, checked((int)book.Text.PagesNum)));
            book.Illustrations.Add(illustration);
            Console.WriteLine($"Иллюстрация на {illustration.Page} страницe");
        }
    }
}
