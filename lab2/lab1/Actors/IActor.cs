using lab2.Products;
using lab2.Wages;
using lab2.Actors;

namespace lab2
{
    /// <summary>
    /// Интерфейс работающего над книгой
    /// </summary>
    public interface IActor<out T> : IPerson where T : ISalary
    {       
        /// <summary>
        /// Заработок
        /// </summary>
        T Salary { get; }
        
        /// <summary>
        /// Работа над книгой
        /// </summary>
        /// <param name="book">Книга, над которой идет работа</param>
        void MakeBook(IBook book);
    }
}
