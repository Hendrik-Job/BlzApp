using BlzApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlzApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
                
        }
        public DbSet<Employee> tblEmployee { get; set; }       
    }
}
