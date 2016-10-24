using System;

namespace lab3.Products
{
    /// <summary>
    /// Текст книги
    /// </summary>
    [Serializable]
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
