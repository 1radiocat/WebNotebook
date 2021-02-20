using Microsoft.EntityFrameworkCore;
using WebNotebook.Models;

namespace WebNotebook.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Record> Records { get; set; }
    }
}
