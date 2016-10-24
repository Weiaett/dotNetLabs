using lab3.Products;
using System;
using System.IO;
using System.Threading;

namespace lab4.Logger
{
    public class Logger : ILogger
    {
        /// <summary>
        /// Событие-перехватчик логируемых событий
        /// </summary>
        public event EventHandler<OnLogArgs<IBook>> OnLog;

        private readonly string filePath;

        /// <summary>
        /// Тип вывода
        /// </summary>
        public OutputType OutputType { set; get; }
        private readonly Semaphore semaphore;
        /// <summary>
        /// Конструктор логера
        /// </summary>
        /// <param name="filePath">Путь к файлу вывода. null, если вывод в консоль</param>
        public Logger(int thr, string filePath = null)
        {
            semaphore = new Semaphore(thr, thr);
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
        public void Subscribe(IBook book)
        {
            book.Writer.OnDoWork += (sender, args) => Actor_OnDoWork(sender, args, EventType.WriterWorks, book);
            book.Illustrator.OnDoWork += (sender, args) => Actor_OnDoWork(sender, args, EventType.IllustratorWorks, book);
            book.Publisher.OnDoWork += (sender, args) => Actor_OnDoWork(sender, args, EventType.PublisherWorks, book);
        }
        private readonly object locker = new object();
        private void Actor_OnDoWork(object sender, DoWorkArgs args, EventType eventType, IBook book)
        {
           new Thread(() =>
            {
                semaphore.WaitOne(-1);
                lock (locker)
                {
                    using (var writer = GetWriter())
                    {
                        OnLog(sender, new OnLogArgs<IBook>()
                        {
                            Args = args,
                            EventType = eventType,
                            Output = writer,
                            Sender = book
                        });
                        //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    }
                }
                semaphore.Release();
            })
            { IsBackground = true }.Start();
        }
  
        /// <summary>
        /// Получить модуль записи
        /// </summary>
        /// <returns></returns>
        public TextWriter GetWriter()
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
