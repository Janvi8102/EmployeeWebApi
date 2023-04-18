using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Model
{
    public class TestDbContext2 : DbContext
    {
        public TestDbContext2(DbContextOptions<TestDbContext2> options) : base(options)
        {
        }
        
        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
