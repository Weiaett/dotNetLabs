using lab3;
using lab3.Products;
using lab3.Wages;
using System;


namespace lab4.Logger
{
    public interface ILogger<T> where T : IBook
    {
        /// <summary>
        /// Событие, создаваемое логером
        /// </summary>
        event EventHandler<OnLogArgs<T>> OnLog;
        /// <summary>
        /// Тип вывода — консоль или файл
        /// </summary>
        OutputType OutputType { get; set; }
        /// <summary>
        /// Подписаться на события книги
        /// </summary>
        /// <param name="book"></param>
        void Subscribe(T book);
    }
}
