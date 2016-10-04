using System;
using System.Collections.Generic;
using lab3.Actors;
using lab3.Wages;

namespace lab3.Products
{
    /// <summary>
    /// Книга
    /// </summary>
    public class Book : Product, IBook
    {
        /// <summary>
        /// Себестоимость книги
        /// </summary>
        public uint CostPrice { get; set; }

        /// <summary>
        /// Иллюстрации
        /// </summary>
        public List<Illustration> Illustrations { get; set; }

        /// <summary>
        /// Иллюстратор
        /// </summary>
        public Illustrator<ISalary> Illustrator { get; }

        /// <summary>
        /// Год издания
        /// </summary>
        public uint PublicationYear { get; set; }

        /// <summary>
        /// Издатель
        /// </summary>
        public Publisher<ISalary> Publisher { get; }

        /// <summary>
        /// Текст книги
        /// </summary>
        public Text Text { get; set; }

        /// <summary>
        /// Писатель
        /// </summary>
        public Writer<ISalary> Writer { get; }

        public Book(Writer<ISalary> writer, Illustrator<ISalary> illustrator, Publisher<ISalary> publisher, string title, uint costPrice)
        {
            Writer = writer;
            Illustrator = illustrator;
            Publisher = publisher;
            Title = title;
            CostPrice = costPrice;
            Illustrations = new List<Illustration>();
            Text = new Text();
        }

        public override string ToString()
        {
            return $"Название: {Title}\n" +
                //$"Автор: {Writer.Name}\n" + 
                //$"Иллюстратор: {Illustrator.Name}\n" + 
                //$"Объем: {Text.PagesNum} стр.\n" + 
                $"Год пуликации: {PublicationYear} г.\n" + ""
                //$"Себестоимость экземпляра: {CostPrice} руб."
                ;
        }

        public override object Clone()
        {
            Book book = new Book(Writer, Illustrator, Publisher, Title, CostPrice);
            List<Illustration> illustrations = new List<Illustration>(Illustrations);
            book.Illustrations = illustrations;
            book.Text = (Text)Text.Clone();
            return book;
        }
    }
}
