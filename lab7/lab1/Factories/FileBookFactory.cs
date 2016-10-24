using lab3.Products;
using lab4.Logger;
using lab5;
using System;
using System.IO;

namespace lab3.Factories
{
    /// <summary>
    /// Фабрика для создания книги из конфигурационного файла
    /// </summary>
    class FileBookFactory : BaseBookFactory
    {
        protected override uint CostPrice { get; set; }

        public FileBookFactory(ILogger logger = null) : base(logger)
        {
        }

        public Book MakeBook(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            if (lines.Length != 5)
                throw new FileFormatException($"Некорректное число строк в конфигурационном файле: {lines.Length} вместо {5}. " + 
                                              $"Требуемая структура: себестоимость, автор, иллюстратор, издатель, название");

            try {
                int costPrice = int.Parse(lines[0]);
                if (costPrice < 0)
                {
                    throw new CostPriceException($"Отрицательное значение себестоимости: {int.Parse(lines[0])}");
                }
                CostPrice = (uint)costPrice;
            }
            catch (FormatException)
            {
                throw new CostPriceException($"Себестоимость задана не числом: {lines[0]}");
            }

            string writerName = lines[1];
            string illustratorName = lines[2];
            string publisherName = lines[3];
            string title = lines[4];
         
            return MakeBook(writerName, illustratorName, publisherName, title);
        }
    }
}
