using SmartLife.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartLife.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SmartLifeClass> SmartLives { get; set; }
        protected AppDbContext()
        {
        }
    }
}
