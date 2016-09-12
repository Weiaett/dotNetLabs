using System;

namespace lab2.Products
{
    /// <summary>
    /// Текст книги
    /// </summary>
    public class Text : Product
    {
        /// <summary>
        /// Количество страниц текста
        /// </summary>
        public uint PagesNum { get; set; }

        public Text() { }

        public Text(uint pagesNum)
        {
            PagesNum = pagesNum;
        }

        public override object Clone()
        {
            return new Text(PagesNum);
        }
    }
}
