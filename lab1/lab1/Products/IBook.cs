using lab1.Actors;
using System.Collections.Generic;

namespace lab1.Products
{
    public interface IBook
    {
        //bool IsSuccessfull { set; get; }

        string Title { get; }

        uint PublicationDate { set; get; }

        uint CostPrice { set; get; }

        Writer Writer { get; }

        Illustrator Illustrator { get; }

        Publisher Publisher { get; }

        Text Text { get; }

        List<Illustration> Illustrations { get; }
    }
}
