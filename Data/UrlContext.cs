using Microsoft.EntityFrameworkCore;
using URLSHORTENERAPI.Models;

namespace URLSHORTENERAPI.Data
{
    public class UrlContext : DbContext
    {
        public UrlContext(DbContextOptions<UrlContext> options) : base(options) { }

        public DbSet<Url> Urls { get; set; }
    }
}
