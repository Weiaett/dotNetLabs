using lab3.Products;

namespace lab3
{
    class Comparators
    {
        public static int SortByTitle(IBook first, IBook second)
        {
            return first.Title.CompareTo(second.Title);
        }

        public static int SortByPublicationYear(IBook first, IBook second)
        {
            return first.PublicationYear.CompareTo(second.PublicationYear);
        }

        public static int SortByTitleDesc(IBook first, IBook second)
        {
            return second.Title.CompareTo(first.Title);
        }

        public static int SortByPublicationYearDesc(IBook first, IBook second)
        {
            return second.PublicationYear.CompareTo(first.PublicationYear);
        }
    }
}

