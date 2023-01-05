using Microsoft.EntityFrameworkCore;
using NewslatterWepApi.Models;

namespace NewslatterWepApi.Controllers
{
    public class NewsLatterDb : DbContext
    {
        public NewsLatterDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<NewsLatter> Newslatters { get; set; }
    }
}
