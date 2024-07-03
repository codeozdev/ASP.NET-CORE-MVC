using ASP.NET_CORE_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_MVC.Entility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }
        public DbSet<KitapTuru> KitapTurleri { get; set; }
    }
}