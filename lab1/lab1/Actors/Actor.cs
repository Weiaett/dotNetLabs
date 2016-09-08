using lab1.Products;
using System;

namespace lab1
{
    public abstract class Actor : IActor
    {
        public string Name { get; }

        protected Actor(string name)
        {
            Name = name;
        }

        protected static Random Random = new Random();

        public abstract void MakeBook(IBook book);

    }
}
