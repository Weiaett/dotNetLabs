using lab1.Products;

namespace lab1
{
    public interface IActor
    {
        string Name { get; }
        
        void MakeBook(IBook book);

        //void PresentBook(IBook book);
    }
}
