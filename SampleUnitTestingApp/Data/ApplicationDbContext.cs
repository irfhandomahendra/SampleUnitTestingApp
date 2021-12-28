using Microsoft.EntityFrameworkCore;
using SampleUnitTestingApp.Models;

namespace SampleUnitTestingApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CreditCardApplication> CreditCardApplications { get; set; }
    }
}