using Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<employee> Employees { get; set; }
    }
}
