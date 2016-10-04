using lab3.Products;
using System.Collections;
using System.Collections.Generic;

namespace lab3
{
    class PublishingOfficeEnumerator<T> : IEnumerator<T> where T : IBook
    {

        private T currBook;
        private int currIndex;
        private IPublishingOffice<T> office;
        
        public PublishingOfficeEnumerator(IPublishingOffice<T> office)
        {
            this.office = office;
            currIndex = -1;
            currBook = default(T);
        }

        public T Current
        {
            get
            {
                return currBook;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return currBook;
            }
        }

        public void Dispose()
        {
            // ресурсов нет
        }

        public bool MoveNext()
        {
            currIndex++;
            if (currIndex >= office.Count)
                return false;
            currBook = office[currIndex];
            return true;
        }

        public void Reset()
        {
            currIndex = -1;
        }
    }
}
