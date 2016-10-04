using lab3.Factories;
using lab3.Products;
using lab3.Wages;
using lab4.Logger;
using System;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger <IBook> logger = new Logger<IBook>();
            logger.OnLog += Logger_OnLog;
            OrdinarBookFactory ordinarFactory = new OrdinarBookFactory(logger);
            CollectionBookFactory collectionFactory = new CollectionBookFactory(logger);

            Book ordinarBook = ordinarFactory.MakeBook("Кац Яков Михайлович", 
                                                       "Шушпанов Аркадий Васильевич",
                                                       "Черногорская Маринна Витальевна",
                                                       "Параноидальное танго");

            Book collectionBook = collectionFactory.MakeBook("Клин Клим Климович",
                                                             "Берестов Демьян Прокофьевич",
                                                             "Факторович Леонид Львович",
                                                             "Эволюция. Тщетность.");

        }

        private static void Logger_OnLog(object sender, OnLogArgs<IBook> e)
        {
            string message;
            string name = ((IActor<ISalary>)sender).Name;
            uint payload = ((DoWorkArgs)e.Args).Payload;
            switch (e.EventType)
            {
                case EventType.WriterWorks:
                    message = $"Писатель {name} написал {payload} страниц.";
                    break;
                case EventType.IllustratorWorks:
                    message = $"Иллюстратор {name} добавил иллюстрацию к {payload} странице.";
                    break;
                case EventType.PublisherWorks:
                    message = $"Издатель {name} издал книгу в {payload} году.";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            e.Output.WriteLine($"Книга \"{e.Sender.Title}\", {DateTime.Now}: {message}");

        }
    }
}
