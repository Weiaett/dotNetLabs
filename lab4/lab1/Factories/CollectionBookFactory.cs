using lab3.Products;
using lab4.Logger;

namespace lab3.Factories
{
    /// <summary>
    /// Фабрика для создания коллекционных книг
    /// </summary>
    class CollectionBookFactory : BaseBookFactory
    {
        protected override uint CostPrice { get; }

        public CollectionBookFactory(ILogger<IBook> logger = null) : base(logger)
        {
            CostPrice = 1500;
        }
    }
}
