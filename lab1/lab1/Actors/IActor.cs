using lab1.Products;

namespace lab1
{
    /// <summary>
    /// Интерфейс работающего над книгой
    /// </summary>
    public interface IActor
    {
        /// <summary>
        /// Имя человека
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Работа над книгой
        /// </summary>
        /// <param name="book">Книга, над которой идет работа</param>
        void MakeBook(IBook book);
    }
}
