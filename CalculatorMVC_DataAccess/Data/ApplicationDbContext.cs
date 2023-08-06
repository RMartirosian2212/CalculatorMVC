using CalculatorMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorMVC_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Calculator> Calculators { get; set; }
    }
}
