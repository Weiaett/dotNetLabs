using lab2.Actors;
using lab2.Products;
using lab2.Wages;
using System.Collections.Generic;

namespace lab2
{
    /// <summary>
    /// Интерфейс издательского дома
    /// </summary>
    /// <typeparam name="T">Параметр обобщенной коллекции</typeparam>
    interface IPublishingOffice<T> : ICollection<T> where T : IBook
    {
        /// <summary>
        /// Название издательства
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Индексатор 
        /// </summary>
        /// <param name="index">Номер элемента</param>
        /// <returns>Элемент под номером index</returns>
        T this[int index] { get; set; }

        void HireActorWithWage(IActor<IWage> actor);

        void HireActorWithReward(IActor<IReward> actor);

        void PrintBooks();

        void PrintMembers();
    }
}
