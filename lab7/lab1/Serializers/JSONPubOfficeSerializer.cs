using lab3;
using lab3.Products;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.IO;

namespace lab5.Serializers
{
    class JSONPubOfficeSerializer<T> : IPubOfficeSerializer<T> where T : Book
    {
        private readonly JsonSerializer serializer;

        public JSONPubOfficeSerializer()
        {
            serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Include;
            serializer.Formatting = Formatting.Indented;
        }

        public void Serialize(PublishingOffice<T> office, string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            using (JsonTextWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, office);
            }
        }

        public PublishingOffice<T> Deserialize(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
            {
                PublishingOffice<T> office = serializer.Deserialize<PublishingOffice<T>>(jsonTextReader);
                return office;
            }
        }
    }
}

