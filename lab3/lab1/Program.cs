using lab3.Actors;
using lab3.Factories;
using lab3.Products;
using lab3.Wages;
using System;

namespace lab3
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

            Book collectionBook1 = collectionFactory.MakeBook("Клин Клим Климович",
                                                             "Берестов Демьян Прокофьевич",
                                                             "Факторович Леонид Львович",
                                                             "Alpha.");

            PublishingOffice<IBook> office = new PublishingOffice<IBook>("Буква")
            {
                ordinarBook,
                collectionBook,
                collectionBook1
            };
            Console.WriteLine("По названию:");
            office.SortBooks(Comparators.SortByTitle);
            office.PrintBooks();
            Console.WriteLine("По году издания:");
            office.SortBooks(Comparators.SortByPublicationYear);
            office.PrintBooks();
            Console.WriteLine("По году издания в обратном порядке:");
            office.SortBooks(Comparators.SortByPublicationYearDesc);
            office.PrintBooks();


            office.HireActorWithReward(new Writer<IReward>("Василий Сергеевич Чесноков", new Reward(300000)));
            office.HireActorWithWage(new Publisher<IWage>("Николай Александрович Клим", new Wage(30000, 31)));
            office.PrintMembers();
            office.InteractWithActors(riseSalary);
            office.PrintMembers();

            office.CountBooks(countCollectionBooks);

            Console.ReadLine();
        }

        private static void riseSalary(IActor<ISalary> actor)
        {
            actor.Salary.Sum += (int)(actor.Salary.Sum * 0.1);
        }

        private static string countCollectionBooks(IPublishingOffice<IBook> office)
        {
            int num = 0;
            foreach (IBook book in office)
            {
                if (book.CostPrice > 1000)
                {
                    num++;
                }
            }
            return $"Издательство выпустило {num} шт. коллекционных книг.";
        }
    }
}
