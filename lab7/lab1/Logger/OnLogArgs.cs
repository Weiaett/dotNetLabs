using lab3.Products;
using System;
using System.IO;

namespace lab4.Logger
{
    /// <summary>
    /// Аргументы события OnLog
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OnLogArgs<T> where T : IBook
    {

        /// <summary>
        /// Аргументы первичного события
        /// </summary>
        public EventArgs Args;

        /// <summary>
        /// Тип события
        /// </summary>
        public EventType EventType;

        /// <summary>
        /// Модуль записи лога
        /// </summary>
        public TextWriter Output;

        /// <summary>
        /// Инициатор логируемого события
        /// </summary>
        public T Sender;
    }
}
