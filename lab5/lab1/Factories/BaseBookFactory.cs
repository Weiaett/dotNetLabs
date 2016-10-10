using lab3.Actors;
using lab3.Products;
using lab3.Wages;
using lab4.Logger;
using System;

namespace lab3.Factories
{
    /// <summary>
    /// Абстрактная фабрика для создания книг
    /// </summary>
    public abstract class BaseBookFactory
    {
        /// <summary>
        /// Себестоимость книги — показатель ее типа
        /// </summary>
        protected abstract uint CostPrice { get; set;  }

        protected ILogger Logger;

        public BaseBookFactory(ILogger logger = null)
        {
            Logger = logger;
        }

        /// <summary>
        /// Создание книги
        /// </summary>
        /// <param name="writerName">Имя писателя</param>
        /// <param name="illustratorName">Имя иллюстратора</param>
        /// <param name="publisherName">Имя издателя</param>
        /// <param name="title">Название книги</param>
        /// <returns></returns>
        public Book MakeBook(string writerName, string illustratorName, string publisherName, string title)
        {
            //Console.WriteLine($"Начата книга {title}");
            Writer<ISalary> writer = new Writer<ISalary>(writerName);
            Illustrator<ISalary> illustrator = new Illustrator<ISalary>(illustratorName);
            Publisher<ISalary> publisher = new Publisher<ISalary>(publisherName);
            Book book = new Book(writer, illustrator, publisher, title, CostPrice);
            Logger?.Subscribe(book);
            Random random = new Random();
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                writer.MakeBook(book);
                illustrator.MakeBook(book);
            }
            publisher.MakeBook(book);
            //Console.WriteLine($"Закончена книга {title}");
            //Console.WriteLine();
            return book;
        }
    }
}
