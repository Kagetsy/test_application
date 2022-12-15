using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database.Models;

namespace WebApplication2.Database
{
    /// <summary>
    /// контекст до базы данных
    /// </summary>
    public class ShortsContext : DbContext
    {
        public ShortsContext(DbContextOptions<ShortsContext> options): base(options)
        {

        }
        /// <summary>
        /// дбсет для таблицы UrlsHistory
        /// </summary>
        public DbSet<UrlsHistory> UrlsHistory { get; set; }
    }
}
