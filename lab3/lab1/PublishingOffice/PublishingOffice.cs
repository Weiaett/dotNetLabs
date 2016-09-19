using lab3.Products;
using System.Collections.Generic;
using System.Collections;
using lab3.Wages;
using System;
using lab3.Actors;

namespace lab3
{
    public class PublishingOffice<T> : IContractProvider<IPerson>, IPublishingOffice<T> where T : IBook
    {
        public string Name { get; }
        private List<T> books;
        public List<IActor<ISalary>> actors { set; get; }

        public PublishingOffice(string name)
        {
            Name = name;
            books = new List<T>();
            actors = new List<IActor<ISalary>>();
        }

        public int Count
        {
            get
            {
                return books.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T this[int index]
        {
            get
            {
                return books[index];
            }

            set
            {
                books[index] = value;
            }
        }

        public void Add(T item)
        {
            books.Add(item);
        }

        public void Clear()
        {
            books.Clear();
        }

        public bool Contains(T item)
        {
            return books.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            books.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return books.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new PublishingOfficeEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PublishingOfficeEnumerator<T>(this);
        }

        public void HireActorWithWage(IActor<IWage> actor)
        {
            actors.Add(actor);
        }

        public void HireActorWithReward(IActor<IReward> actor)
        {
            actors.Add(actor);
        }

        public void PrintBooks()
        {
            Console.WriteLine($"***\nКниги издательства {Name}:");
            foreach (T book in books)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine($"***");
        }

        public void PrintMembers()
        {
            Console.WriteLine($"***\nВ издательстве {Name} работают:");
            foreach (IActor<ISalary> actor in actors)
            {
                actor.Introduce();
            }
            Console.WriteLine($"***");
        }

        public void PrintContract(IPerson person)
        {
            Console.WriteLine($"***\nКонтракт издательства {Name}:");
            person.Introduce();
            Console.WriteLine($"***");
        }

        //Comparison — это делегат
        //public delegate int Comp(IBook first, IBook second)
        public void SortBooks(Comparison<T> comparator)
        {
            books.Sort(comparator);
        }

        public void InteractWithActors(Action<IActor<ISalary>> interaction)
        {
            foreach (IActor<ISalary> actor in actors)
            {
                interaction(actor);
            }
        }

        public void CountBooks(Func<IPublishingOffice<T>, int> counter)
        {
            Console.WriteLine($"Издательство выпустило {counter(this)} шт. коллекционных книг.");
        }
    }
}
