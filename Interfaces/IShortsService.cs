using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    /// <summary>
    /// интерфейс для создания и получения короткого урл и получения исходного
    /// </summary>
    public interface IShortsService
    {
        /// <summary>
        /// создать короткое урл
        /// </summary>
        /// <param name="url">длинное урл</param>
        /// <param name="urlToSave">урл для qr-кода</param>
        Task<string> CreateUrl(string url, string urlToSave);
        /// <summary>
        /// получить полное урл
        /// </summary>
        /// <param name="shortUrl">короткое урл</param>
        /// <returns>урл для редиректа</returns>
        string GetUrl(string shortUrl);
    }
}
