namespace lab3.Factories
{
    /// <summary>
    /// Фабрика для создания обычных книг
    /// </summary>
    public class OrdinarBookFactory : BaseBookFactory
    {
        protected override uint CostPrice { get; }

        public OrdinarBookFactory()
        {
            CostPrice = 150;
        }
    }
}
