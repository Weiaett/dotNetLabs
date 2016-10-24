using lab3;
using lab3.Products;
using lab3.Wages;
using System;


namespace lab4.Logger
{
    public interface ILogger
    {
        /// <summary>
        /// Событие, создаваемое логером
        /// </summary>
        event EventHandler<OnLogArgs<IBook>> OnLog;
        /// <summary>
        /// Тип вывода — консоль или файл
        /// </summary>
        OutputType OutputType { get; set; }
        /// <summary>
        /// Подписаться на события книги
        /// </summary>
        /// <param name="book"></param>
        void Subscribe(IBook book);
    }
}
