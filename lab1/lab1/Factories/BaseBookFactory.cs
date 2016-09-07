using lab1.Actors;
using lab1.Products;
using System;

namespace lab1.Factories
{
    public abstract class BaseBookFactory
    {
        protected abstract uint CostPrice { get; }

        public Book MakeBook(string writerName, string illustratorName, string publisherName, string title)
        {
            Console.WriteLine($"Начата книга {title}");
            Writer writer = new Writer(writerName);
            Illustrator illustrator = new Illustrator(illustratorName);
            Publisher publisher = new Publisher(publisherName);
            Book book = new Book(writer, illustrator, publisher, title, CostPrice);
            Random random = new Random();
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                writer.MakeBook(book);
                illustrator.MakeBook(book);
            }
            publisher.MakeBook(book);
            Console.WriteLine($"Закончена книга {title}");
            Console.WriteLine();
            return book;
        }
    }
}
