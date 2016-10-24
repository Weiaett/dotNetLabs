using System;
using lab3.Products;
using lab3.Wages;
using lab4.Logger;

namespace lab3.Actors
{
    /// <summary>
    /// Иллюстратор
    /// </summary>
    [Serializable]
    public class Illustrator<T> : Actor<T> where T : Salary
    {
        [field: NonSerialized]
        public override event EventHandler<DoWorkArgs> OnDoWork;
        public Illustrator(string name, T salary) : base(name, salary)
        {
        }
        public Illustrator(string name) : base(name)
        {
        }

        private Illustrator() { }

        public override void Introduce()
        {
            Console.WriteLine($"Иллюстратор {Name}");
            Salary.Print();
        }

        /// <summary>
        /// Иллюстратор добавляет иллюстрации к уже написанным страницам книги
        /// </summary>
        /// <param name="book"></param>
        public override void MakeBook(IBook book)
        {
            uint page = (uint)Random.Next(5, checked((int)book.Text.PagesNum));
            Illustration illustration = new Illustration(page);
            book.Illustrations.Add(illustration);
            OnDoWork(this, new DoWorkArgs() { Payload = page });
            //Console.WriteLine($"Иллюстрация на {illustration.Page} страницe");
        }
    }
}
