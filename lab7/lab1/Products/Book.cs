using System;
using System.Collections.Generic;
using lab3.Actors;
using lab3.Wages;
using Newtonsoft.Json;

namespace lab3.Products
{
    /// <summary>
    /// Книга
    /// </summary>
    [Serializable]
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
        public Illustrator<Salary> Illustrator { get; set; }

        /// <summary>
        /// Год издания
        /// </summary>
        public uint PublicationYear { get; set; }

        /// <summary>
        /// Издатель
        /// </summary>
        public Publisher<Salary> Publisher { get; set; }

        /// <summary>
        /// Текст книги
        /// </summary>
        public Text Text { get; set; }

        /// <summary>
        /// Писатель
        /// </summary>
        public Writer<Salary> Writer { get; set; }

        public Book(Writer<Salary> writer, Illustrator<Salary> illustrator, Publisher<Salary> publisher, string title, uint costPrice)
        {
            Writer = writer;
            Illustrator = illustrator;
            Publisher = publisher;
            Title = title;
            CostPrice = costPrice;
            Illustrations = new List<Illustration>();
            Text = new Text();
        }

        private Book() { }

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
