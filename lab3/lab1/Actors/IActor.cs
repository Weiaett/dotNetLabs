using lab3.Products;
using lab3.Wages;
using lab3.Actors;

namespace lab3
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
