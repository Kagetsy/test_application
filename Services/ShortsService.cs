using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Database;
using WebApplication2.Database.Models;
using WebApplication2.Interfaces;

namespace WebApplication2.Services
{
    public class ShortsService : IShortsService
    {
        private readonly ShortsContext _context;
        private readonly ShortsAdapter _shortsAdapter;
        private readonly IGenerateQR _generateQR;
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="context">контекст до базы</param>
        public ShortsService(ShortsContext context, ShortsAdapter shortsAdapter, IGenerateQR generateQR)
        {
            _context = context;
            _shortsAdapter = shortsAdapter;
            _generateQR = generateQR;
        }
        public async Task<string> CreateUrl(string url, string urlToSave)
        {
            try
            {
                if (UrlsHistoryExists(url))
                {
                    return GetExistToken(url); 
                }

                var newUrl = new UrlsHistory
                {
                    url = url,
                    token = Guid.NewGuid().ToString()
                };
                _context.Add(newUrl);
                await _context.SaveChangesAsync();

                _shortsAdapter.Add(newUrl);
                _generateQR.GenerateQr($"{urlToSave}?token={newUrl.token}", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newUrl.token));
                return newUrl.token;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetUrl(string token)
        {
            try
            {
                var url = _shortsAdapter.UrlsHistories.FirstOrDefault(_ => _.token == token);
                if (url == null)
                {
                    url = _context.UrlsHistory.FirstOrDefault(_ => _.token == token);
                    if (url != null)
                    {
                        return url.url;
                    }
                    return null;
                }
                return url.url;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// получить существующий токен
        /// </summary>
        /// <param name="url">ссылка</param>
        /// <returns>токен</returns>
        private string GetExistToken(string url)
        {
            var savedUrl = _shortsAdapter.UrlsHistories.FirstOrDefault(_ => _.url == url);
            if (savedUrl == null)
            {
                savedUrl = _context.UrlsHistory.FirstOrDefault(_ => _.url == url);
                if (savedUrl != null)
                {
                    return savedUrl.token;
                }
                return null;
            }
            return savedUrl.token;
        }
        /// <summary>
        /// существует ли в базе ссылка
        /// </summary>
        /// <param name="url">ссылка</param>
        /// <returns>существует ли: да\нет</returns>
        private bool UrlsHistoryExists(string url)
        {
            if (_shortsAdapter.Exist(url))
            {
                return true;
            }
            return _context.UrlsHistory.Any(e => e.url == url);
        }
        /// <summary>
        /// удалить ссылку. НЕ ИСОЛЬЗУЕТСЯ (в целом, можно и реализовать)
        /// </summary>
        /// <param name="id">идентификатор ссылки</param>
        public async void Remove(int id)
        {
            var urlsHistory = await _context.UrlsHistory.FindAsync(id);
            _context.UrlsHistory.Remove(urlsHistory);
            await _context.SaveChangesAsync();
            _shortsAdapter.Remove(urlsHistory);
        }
    }
}
