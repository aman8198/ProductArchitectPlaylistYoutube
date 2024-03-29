using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) 
        {

        }

        public DbSet<Employee> Employees { get; set; } 
    }
}
