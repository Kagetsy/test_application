using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Database.Models
{
    /// <summary>
    /// модель для базы, содрежит информацию по уже записанным в базу ссылкам
    /// </summary>
    public class UrlsHistory
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// исходная ссылка
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// короткая ссылка
        /// </summary>
        public string token { get; set; }
    }
}
