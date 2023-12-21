using Microsoft.EntityFrameworkCore;
using TasklyWebApp.Models;

namespace TasklyWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Models.ToDo> ToDos { get; set; }
    }
}
