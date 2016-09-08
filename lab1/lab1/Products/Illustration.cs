namespace lab1.Products
{
    /// <summary>
    /// Иллюстрация к книге
    /// </summary>
    public class Illustration : Product
    {
        /// <summary>
        /// Страница, к которой относится иллюстрация
        /// </summary>
        public uint Page { get; }

        public Illustration(uint page)
        {
            Page = page;
        }
    }
}
