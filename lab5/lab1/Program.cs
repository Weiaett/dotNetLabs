using lab3.Factories;
using lab3.Products;
using lab3.Wages;
using lab4.Logger;
using lab5;
using System;
using System.IO;
using lab5.Logger;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectPath = "..\\..\\";
            Logger logger = new Logger(Path.Combine(projectPath, "log.txt"));
            logger.OnLog += Logger_OnLog;
            FileBookFactory factory = new FileBookFactory(logger);

            ExceptonLogger exLogger = new ExceptonLogger(Path.Combine(projectPath, "exeptions_log.txt"));
            string configsPath = Path.Combine(projectPath, "Configs");
            
            if (Directory.Exists(configsPath)) {
                string[] fileEntries = Directory.GetFiles(configsPath);
                foreach (string fileName in fileEntries)
                {
                    try {
                        Book book = factory.MakeBook(fileName);
                    }
                    catch (UserException e)
                    {
                        exLogger.LogUserException(e);
                    }
                    catch (Exception e)
                    {
                        exLogger.LogSystemException(e);
                    }
                }
            }
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
