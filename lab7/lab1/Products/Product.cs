using System;

namespace lab3.Products
{
    /// <summary>
    /// Абстрактный класс для сущностей, создаваемых в процессе работы над книгой
    /// </summary>
    [Serializable]
    public abstract class Product : ICloneable
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }

        public abstract object Clone();
        
    }
}
