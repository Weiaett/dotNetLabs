using System;
using System.Collections.Generic;
using lab1.Actors;

namespace lab1.Products
{
    public class Book : Product, IBook
    {
        public uint CostPrice { get; set; }

        public List<Illustration> Illustrations { get; }

        public Illustrator Illustrator { get; }

        //public bool IsSuccessfull { get; set; }

        public uint PublicationDate { get; set; }

        public Publisher Publisher { get; }

        public Text Text { get; }

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
                $"Год пуликации: {PublicationDate} г.\n" + 
                $"Себестоимость экземпляра: {CostPrice} руб.";
        }
    }
}
