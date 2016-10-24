using lab3;
using lab3.Products;

namespace lab5.Serializers
{
    interface IPubOfficeSerializer<T> where T : IBook
    {
        /// <summary>
        /// Сериализация коллекции
        /// </summary>
        /// <param name="office">Издательский дом</param>
        /// <param name="filePath">Путь к файлу</param>
        void Serialize(PublishingOffice<T> office, string filePath);
        /// <summary>
        /// Ltcthbfkbpfwbz rjkktrwbb
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        PublishingOffice<T> Deserialize(string filePath);
    }
}
