using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Database;
using WebApplication2.Interfaces;

namespace WebApplication2.Controllers
{
    /// <summary>
    /// контроллер при помощи которого создаем короткую ссылку
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ShortsController : ControllerBase
    {
        private readonly IShortsService _shortsService;
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="shortsService">интерфейс, который работает с ссылками и базой</param>
        public ShortsController(IShortsService shortsService)
        {
            _shortsService = shortsService;
        }
        /// <summary>
        /// создать короткий токен
        /// </summary>
        /// <param name="url">ссылка по которой происходит генерация</param>
        /// <returns>токен</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]string url)
        {
            
            if (!string.IsNullOrWhiteSpace(url))
            {
                var stringUrl = Request.Scheme + "://" + Request.Host.Value + Request.Path;
                var shortUrl = await _shortsService.CreateUrl(url, stringUrl);
                return Ok(shortUrl);
            }
            return BadRequest();
        }
        /// <summary>
        /// перейти по токену по ссылке. В сваггере не пашет:(
        /// </summary>
        /// <param name="token">токен</param>
        /// <returns>редирект</returns>
        [HttpGet]
        public async Task<IActionResult> OpenPage([FromQuery]string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var res = _shortsService.GetUrl(token);
                return Redirect(res);
            }
            return BadRequest();
        }
    }
}
