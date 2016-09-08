using lab1.Actors;
using System.Collections.Generic;

namespace lab1.Products
{
    /// <summary>
    /// Интерфейс книги
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// Название
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Год публикации
        /// </summary>
        uint PublicationYear { set; get; }

        /// <summary>
        /// Себестоимость
        /// </summary>
        uint CostPrice { set; get; }

        /// <summary>
        /// Писатель
        /// </summary>
        Writer Writer { get; }

        /// <summary>
        /// Иллюстратор
        /// </summary>
        Illustrator Illustrator { get; }

        /// <summary>
        /// Издатель
        /// </summary>
        Publisher Publisher { get; }

        /// <summary>
        /// Текст книги
        /// </summary>
        Text Text { get; }

        /// <summary>
        /// Иллюстрации
        /// </summary>
        List<Illustration> Illustrations { get; }
    }
}
