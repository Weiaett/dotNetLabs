using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5.Logger
{
    /// <summary>
    /// Интерфейс логгера исключений
    /// </summary>
    interface IExceptionLogger
    {
        void LogSystemException(Exception ex);
        void LogUserException(Exception ex);
    }
}
