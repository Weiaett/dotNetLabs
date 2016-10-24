using lab3;
using lab3.Products;
using System.IO;
using System.Xml.Serialization;

namespace lab5.Serializers
{
    public class XMLPubOfficeSerializer<T> : IPubOfficeSerializer<T> where T : Book
    {
        private readonly XmlSerializer serializer;

        public XMLPubOfficeSerializer()
        {
            serializer = new XmlSerializer(typeof(PublishingOffice<T>));
        }

        public void Serialize(PublishingOffice<T> office, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, office);
            }
        }

        public PublishingOffice<T> Deserialize(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                return (PublishingOffice<T>) serializer.Deserialize(reader);
            }
        }
    }
}
