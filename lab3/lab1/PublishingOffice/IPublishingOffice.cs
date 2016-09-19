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

        /// <summary>
        /// Сортировка книг издательства 
        /// </summary>
        /// <param name="comparator">Метод, сравнивающий два объекта одного типа</param>
        //public delegate int Comp(IBook first, IBook second);
        void SortBooks(Comparison<T> comparator);

        /// <summary>
        /// Взаимодействие с сотрудниками
        /// </summary>
        /// <param name="interaction">Делегат, инкапсулирующий метод взаимодействия</param>
        void InteractWithActors(Action<IActor<ISalary>> interaction);

        /// <summary>
        /// Подсчет книг, удовлетворяющих определенным в counter параметрам
        /// </summary>
        /// <param name="counter">Делегат, инкапсулирующий метод подсчета</param>
        void CountBooks(Func<IPublishingOffice<T>, int> counter);
    }
}
