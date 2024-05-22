using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using URLSHORTENERAPI.Data;
using URLSHORTENERAPI.Helper;
using URLSHORTENERAPI.Models;

namespace UrlShortenerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly UrlContext _context;

        public UrlsController(UrlContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ShortenUrl([FromBody] Url url)
        {
            if (string.IsNullOrEmpty(url.LongURL))
            {
                return BadRequest("Invalid URL.");
            }

            url.ShortURL = Logic.GenerateShortUrl();
            url.CreatedAt = DateTime.UtcNow;
            _context.Urls.Add(url);
            await _context.SaveChangesAsync();

            return Ok(url);
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> GetOriginalUrl(string shortUrl)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(u => u.ShortURL == shortUrl);
            if (url == null)
            {
                return NotFound("URL not found.");
            }

            return Redirect(url.LongURL);
        }
    }
}
