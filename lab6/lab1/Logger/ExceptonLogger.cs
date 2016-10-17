using System;
using System.Threading;

namespace lab5.Logger
{
    /// <summary>
    /// Логер исключений
    /// </summary>
    public class ExceptonLogger : lab4.Logger.Logger, IExceptionLogger
    {
        public ExceptonLogger(string filePath = null) : base(filePath)
        {

        }

        private readonly object locker = new object();
        /// <summary>
        /// Логирование системных исключений
        /// </summary>
        /// <param name="e">Логируемое исключение</param>
        public void LogSystemException(Exception e)
        {
            new Thread(() =>
            {
                lock (locker)
                {
                    using (var writer = GetWriter())
                    {
                        writer.WriteLine($"Системное исключение: {DateTime.Now}, {e.GetType()}, {e.Message}\n");
                    }
                }
            });
        }

        /// <summary>
        /// Логирование пользовательских исключений
        /// </summary>
        /// <param name="e">Логируемое исключение</param>
        public void LogUserException(Exception ex)
        {
            new Thread(() =>
            {
                lock (locker)
                {
                    using (var writer = GetWriter())
                    {
                        writer.WriteLine($"Пользовательское исключение: {DateTime.Now}, {ex.GetType()}, {ex.Message}\n");
                    }
                }
            });
        }
    }
}
