using lab3.Actors;
using lab3.Products;
using lab3.Wages;
using System;
using System.Collections.Generic;

namespace lab3
{
    /// <summary>
    /// Интерфейс издательского дома
    /// </summary>
    /// <typeparam name="T">Параметр обобщенной коллекции</typeparam>
    public interface IPublishingOffice<T> : ICollection<T> where T : IBook
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

        //public delegate int Comp(IBook first, IBook second);
        void SortBooks(Comparison<T> comparator);
    }
}
