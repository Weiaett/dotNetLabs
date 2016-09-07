using lab1.Factories;
using lab1.Products;
using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            OrdinarBookFactory ordinarFactory = new OrdinarBookFactory();
            CollectionBookFactory collectionFactory = new CollectionBookFactory();

            Book ordinarBook = ordinarFactory.MakeBook("Кац Яков Михайлович", 
                                                       "Шушпанов Аркадий Васильевич",
                                                       "Черногорская Маринна Витальевна",
                                                       "Параноидальное танго");

            Book collectionBook = collectionFactory.MakeBook("Клин Клим Климович",
                                                             "Берестов Демьян Прокофьевич",
                                                             "Факторович Леонид Львович",
                                                             "Эволюция. Тщетность.");
            Console.WriteLine(ordinarBook.ToString());
            Console.WriteLine();
            Console.WriteLine(collectionBook.ToString());
            Console.ReadLine();
        }
    }
}
