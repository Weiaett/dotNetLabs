using lab3.Products;
using lab3.Wages;
using lab4.Logger;
using System;

namespace lab3
{
    [Serializable]
    public abstract class Actor<T> : IActor<T> where T : Salary
    {
        public string Name { get; set; }

        public T Salary { get; set; }

        abstract public event EventHandler<DoWorkArgs> OnDoWork;

        protected Actor(string name)
        {
            Name = name;
        }
        protected Actor(string name, T salary)
        {
            Name = name;
            Salary = salary;
        }

        protected Actor() { }

        protected static Random Random = new Random();

        public abstract void MakeBook(IBook book);

        public abstract void Introduce();
    }
}
