using lab3.Factories;
using lab3.Products;
using lab3.Wages;
using lab4.Logger;
using lab5;
using System;
using System.IO;
using lab5.Logger;
using System.Threading.Tasks;
using System.Threading;
using lab5.Serializers;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectPath = "..\\..\\";
            Logger logger = new Logger(6, Path.Combine(projectPath, "log.txt"));
            logger.OnLog += Logger_OnLog;
            OrdinarBookFactory factory = new OrdinarBookFactory(logger);

            PublishingOffice<Book> office = new PublishingOffice<Book>("Буква");
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Генерация книг");
            for (int i = 0; i < 3; i++)
            {
                office.Add(factory.MakeBook("Кац Яков Михайлович",
                                            "Шушпанов Аркадий Васильевич",
                                            "Черногорская Маринна Витальевна",
                                            $"Книга {i}"));

            }
            Console.WriteLine("Генерация завершена\n");

            BinaryPubOfficeSerializer<Book> binSerializer = new BinaryPubOfficeSerializer<Book>();
            JSONPubOfficeSerializer<Book> jsonSerializer = new JSONPubOfficeSerializer<Book>();
            XMLPubOfficeSerializer<Book> xmlSerializer = new XMLPubOfficeSerializer<Book>();

            PublishingOffice<Book> evilOffice = new PublishingOffice<Book>();
            evilOffice = jsonSerializer.Deserialize(Path.Combine(projectPath, "office_input.json"));
            //evilOffice = xmlSerializer.Deserialize(Path.Combine(projectPath, "office_input.xml"));
            //evilOffice = binSerializer.Deserialize(Path.Combine(projectPath, "office_input.bin"));

            jsonSerializer.Serialize(evilOffice, Path.Combine(projectPath, "office_output.json")); // проверка

            binSerializer.Serialize(office, Path.Combine(projectPath, "office.bin"));
            jsonSerializer.Serialize(office, Path.Combine(projectPath, "office.json"));
            xmlSerializer.Serialize(office, Path.Combine(projectPath, "office.xml"));

            //office.SortBooksAsync(Comparators.SortByPublicationYear,
            //    (progressProcs, book) => Console.WriteLine($"Процент сортировки: {progressProcs}%\nКнига: {book}\n")).Wait();
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
