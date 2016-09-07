namespace lab1.Factories
{
    class CollectionBookFactory : BaseBookFactory
    {
        protected override uint CostPrice { get; }

        public CollectionBookFactory()
        {
            CostPrice = 1500;
        }
    }
}
