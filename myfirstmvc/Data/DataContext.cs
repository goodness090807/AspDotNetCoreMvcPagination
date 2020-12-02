using Microsoft.EntityFrameworkCore;
using myfirstmvc.Models;

namespace myfirstmvc.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUsers> appUsers { get; set; }

        public DbSet<Posts> posts { get; set; }
    }
}