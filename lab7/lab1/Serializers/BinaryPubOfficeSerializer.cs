using lab3;
using lab3.Products;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab5.Serializers
{
    public class BinaryPubOfficeSerializer<T> : IPubOfficeSerializer<T> where T : Book
    {
        private readonly BinaryFormatter serializer;

        public BinaryPubOfficeSerializer()
        {
            serializer = new BinaryFormatter();
        }

        public void Serialize(PublishingOffice<T> office, string filename)
        {
            using (FileStream stream = new FileStream(filename, FileMode.Create))
            {
                serializer.Serialize(stream, office);
            }
        }

       
        public PublishingOffice<T> Deserialize(string inputFile)
        {
            using (FileStream stream = new FileStream(inputFile, FileMode.Open))
            {
                return (PublishingOffice<T>) serializer.Deserialize(stream);
            }
        }
    }
}
