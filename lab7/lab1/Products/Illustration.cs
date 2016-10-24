using System;

namespace lab3.Products
{
    /// <summary>
    /// Иллюстрация к книге
    /// </summary>
    [Serializable]
    public class Illustration : Product
    {
        /// <summary>
        /// Страница, к которой относится иллюстрация
        /// </summary>
        public uint Page { get; set; }

        public Illustration(uint page)
        {
            Page = page;
        }

        public override object Clone()
        {
            return new Illustration(Page);
        }

        private Illustration() { }
    }
}
