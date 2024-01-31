using BlazorPOC_Net8Crud.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorPOC_Net8Crud.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<User> User { get; set; }

    }
}
