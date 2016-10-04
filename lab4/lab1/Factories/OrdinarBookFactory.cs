using lab3.Products;
using lab4.Logger;

namespace lab3.Factories
{
    /// <summary>
    /// Фабрика для создания обычных книг
    /// </summary>
    public class OrdinarBookFactory : BaseBookFactory
    {
        protected override uint CostPrice { get; }

        public OrdinarBookFactory(ILogger<IBook> logger = null) : base(logger)
        {
            CostPrice = 150;
        }
    }
}
