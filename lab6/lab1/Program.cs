using lab3.Factories;
using lab3.Products;
using lab3.Wages;
using lab4.Logger;
using lab5;
using System;
using System.IO;
using lab5.Logger;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectPath = "..\\..\\";
            Logger logger = new Logger(Path.Combine(projectPath, "log.txt"));
            logger.OnLog += Logger_OnLog;
            OrdinarBookFactory factory = new OrdinarBookFactory(logger);

            PublishingOffice<IBook> office = new PublishingOffice<IBook>("Буква");

            Console.WriteLine("Генерация книг");
            for (int i = 0; i < 100; i++)
            {
                office.Add(factory.MakeBook("Кац Яков Михайлович",
                                            "Шушпанов Аркадий Васильевич",
                                            "Черногорская Маринна Витальевна",
                                            $"Книга {i}"));

            }
            Console.WriteLine("Генерация завершена");
            Task task = office.SortBooksAsync(Comparators.SortByPublicationYear, new Progress<int>(ShowProgress));
            task.Wait();
            //Console.Read();
           office.PrintBooks();
        }

        private static void ShowProgress(int progress)
        {
            Console.WriteLine("Процент сортировки: {0}%", progress);
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
