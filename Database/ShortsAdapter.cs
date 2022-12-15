using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database.Models;

namespace WebApplication2.Database
{
    /// <summary>
    /// адаптер для кэширования ссылок 
    /// </summary>
    public class ShortsAdapter
    {
        private List<UrlsHistory> _urlsHistories;
        /// <summary>
        /// информация по уже существующим ссылкам
        /// </summary>
        public List<UrlsHistory> UrlsHistories
        {
            get
            {
                if (_urlsHistories == null)
                {
                    _urlsHistories = new List<UrlsHistory>();
                }
                return _urlsHistories;
            }
            set
            {
                _urlsHistories = value;
            }
        }
        /// <summary>
        /// добавть в коллекцию значение
        /// </summary>
        /// <param name="urlsHistory">ссылка, которую нужно добавить</param>
        public void Add(UrlsHistory urlsHistory)
        {
            UrlsHistories.Add(urlsHistory);
        }

        /// <summary>
        /// удалить из коллекции
        /// </summary>
        /// <param name="urlsHistory">ссылка, которую нужно удалить</param>
        public void Remove(UrlsHistory urlsHistory)
        {
            if (Exist(urlsHistory.url))
            {
                UrlsHistories.Remove(urlsHistory);
            }
        }
        /// <summary>
        /// существует ли в коллекции ссылка
        /// </summary>
        /// <param name="url">ссылка</param>
        /// <returns>результат проверки</returns>
        public bool Exist(string url)
        {
            return UrlsHistories.Any(_ => _.url == url);
        }
    }
}
