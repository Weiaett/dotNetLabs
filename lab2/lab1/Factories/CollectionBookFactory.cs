namespace lab2.Factories
{
    /// <summary>
    /// Фабрика для создания коллекционных книг
    /// </summary>
    class CollectionBookFactory : BaseBookFactory
    {
        protected override uint CostPrice { get; }

        public CollectionBookFactory()
        {
            CostPrice = 1500;
        }
    }
}
