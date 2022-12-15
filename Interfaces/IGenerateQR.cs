using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    /// <summary>
    /// интерфейс для генерации картинки с qr-кодом
    /// </summary>
    public interface IGenerateQR
    {
        /// <summary>
        /// генерация qr-кода
        /// </summary>
        /// <param name="url">ссылка</param>
        /// <param name="fileName">имя файла</param>
        void GenerateQr(string url, string fileName);
    }
}
