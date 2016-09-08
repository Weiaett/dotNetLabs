using System.Collections.Generic;
using lab1.Actors;

namespace lab1.Products
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
        public List<Illustration> Illustrations { get; }

        /// <summary>
        /// Иллюстратор
        /// </summary>
        public Illustrator Illustrator { get; }

        /// <summary>
        /// Год издания
        /// </summary>
        public uint PublicationYear { get; set; }

        /// <summary>
        /// Издатель
        /// </summary>
        public Publisher Publisher { get; }

        /// <summary>
        /// Текст книги
        /// </summary>
        public Text Text { get; }

        /// <summary>
        /// Писатель
        /// </summary>
        public Writer Writer { get; }

        public Book(Writer writer, Illustrator illustrator, Publisher publisher, string title, uint costPrice)
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
                $"Автор: {Writer.Name}\n" + 
                $"Иллюстратор: {Illustrator.Name}\n" + 
                $"Объем: {Text.PagesNum} стр.\n" + 
                $"Год пуликации: {PublicationYear} г.\n" + 
                $"Себестоимость экземпляра: {CostPrice} руб.";
        }
    }
}
