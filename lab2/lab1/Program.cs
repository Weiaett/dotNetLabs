using lab2.Actors;
using lab2.Factories;
using lab2.Products;
using lab2.Wages;
using System;

namespace lab2
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

            PublishingOffice<IBook> office = new PublishingOffice<IBook>("Буква")
            {
                ordinarBook,
                collectionBook
            };
            office.PrintBooks();
            Console.WriteLine($"Удалим одну книгу");
            office.Remove(ordinarBook);
            office.PrintBooks();
            Console.WriteLine();

            office.HireActorWithReward(new Writer<IReward>("Василий Сергеевич Чесноков", new Reward(300000)));
            office.HireActorWithWage(new Publisher<IWage>("Николай Александрович Клим", new Wage(30000, 31)));
            office.PrintMembers();

            IContractProvider<IPerson> personContract = new PublishingOffice<IBook>("Эксмо");
            IContractProvider<IActor<ISalary>> actorContract = personContract;
            actorContract.PrintContract(new Publisher<IWage>("Юлия Львовна Липская", new Wage(7000, 7)));

            Console.ReadLine();
        }
    }
}
