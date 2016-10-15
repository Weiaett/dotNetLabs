using System;

namespace lab5
{
    /// <summary>
    /// Базовое пользовательское исключение
    /// </summary>
    public class UserException : ApplicationException
    {
        public UserException(string message) : base(message)
        {

        }

        public UserException()
        {

        }
    }

    /// <summary>
    /// Пользовательское исключение, возникающее при неверной структуре конфигурационного файла
    /// </summary>
    public class FileFormatException : UserException
    {
        public FileFormatException(string message) : base(message)
        {

        }

        public FileFormatException() : base("Неверный формат файл")
        {

        }
    }

    /// <summary>
    /// Пользовательское исключение, возникающее при некорректном значении себестоимости книги
    /// </summary>
    public class CostPriceException : UserException
    {
        public CostPriceException(string message) : base(message)
        {

        }

        public CostPriceException() : base("Некорректная себестоимость")
        {

        }
    }

}
