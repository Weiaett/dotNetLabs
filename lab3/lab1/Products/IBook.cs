using lab3.Actors;
using lab3.Wages;
using System.Collections.Generic;

namespace lab3.Products
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
        Writer<ISalary> Writer { get; }

        /// <summary>
        /// Иллюстратор
        /// </summary>
        Illustrator<ISalary> Illustrator { get; }

        /// <summary>
        /// Издатель
        /// </summary>
        Publisher<ISalary> Publisher { get; }

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
