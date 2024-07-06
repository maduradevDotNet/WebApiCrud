using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebApiCrud.Model;
using static Azure.Core.HttpHeader;

namespace WebApiCrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id=1,
                Name = "fgfgfg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id=2,
                Name = "tgtgfgfg"
            });
        }
    
    }
}
