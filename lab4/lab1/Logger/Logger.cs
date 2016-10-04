using lab3.Products;
using System;
using System.IO;

namespace lab4.Logger
{
    public class Logger<T> : ILogger<T> where T : IBook
    {
        /// <summary>
        /// Событие-перехватчик логируемых событий
        /// </summary>
        public event EventHandler<OnLogArgs<T>> OnLog;

        private readonly string filePath;

        /// <summary>
        /// Тип вывода
        /// </summary>
        public OutputType OutputType { set; get; }

        /// <summary>
        /// Конструктор логера
        /// </summary>
        /// <param name="filePath">Путь к файлу вывода. null, если вывод в консоль</param>
        public Logger(string filePath = null)
        {
            if (filePath == null)
            {
                OutputType = OutputType.Console;
            }
            else
            {
                OutputType = OutputType.File;
                this.filePath = filePath;

                if (!File.Exists(filePath))
                {
                    FileStream fs = File.Create(filePath);
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// Подписываемся на логируемые события
        /// </summary>
        /// <param name="book">Книга, работу над которой логируем</param>
        public void Subscribe(T book)
        {
            book.Writer.OnDoWork += (sender, args) => Actor_OnDoWork(sender, args, EventType.WriterWorks, book);
            book.Illustrator.OnDoWork += (sender, args) => Actor_OnDoWork(sender, args, EventType.IllustratorWorks, book);
            book.Publisher.OnDoWork += (sender, args) => Actor_OnDoWork(sender, args, EventType.PublisherWorks, book);
        }

        private void Actor_OnDoWork(object sender, DoWorkArgs args, EventType eventType, T book)
        {
            using (var writer = GetWriter())
            {
                OnLog(sender, new OnLogArgs<T>() {
                    Args = args,
                    EventType = eventType,
                    Output = writer,
                    Sender = book
                });
            }
        }

        /// <summary>
        /// Получить модуль записы
        /// </summary>
        /// <returns></returns>
        private TextWriter GetWriter()
        {
            return OutputType == OutputType.Console ? Console.Out : File.AppendText(filePath);
        }
    }

    /// <summary>
    /// Тип логируемого события
    /// </summary>
    public enum EventType
    {
        WriterWorks,
        IllustratorWorks,
        PublisherWorks
    }

    /// <summary>
    /// Тип вывода — консоль или файл
    /// </summary>
    public enum OutputType
    {
        Console,
        File
    }
}
