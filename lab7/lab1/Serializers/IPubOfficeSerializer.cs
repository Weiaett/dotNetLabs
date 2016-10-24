using lab3;
using lab3.Products;

namespace lab5.Serializers
{
    interface IPubOfficeSerializer<T> where T : IBook
    {
        void Serialize(PublishingOffice<T> playlist, string fileName);
        PublishingOffice<T> Deserialize(string fileName);
    }
}
