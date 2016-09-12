using lab2.Products;
using lab2.Wages;
using System;

namespace lab2
{
    public abstract class Actor<T> : IActor<T> where T : ISalary
    {
        public string Name { get; }

        public T Salary { get; }

        protected Actor(string name)
        {
            Name = name;
        }
        protected Actor(string name, T salary)
        {
            Name = name;
            Salary = salary;
        }

        protected static Random Random = new Random();

        public abstract void MakeBook(IBook book);

        public abstract void Introduce();
    }
}
