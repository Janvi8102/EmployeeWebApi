using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Model
{
    public class TestDbContext1: DbContext
    {
        public TestDbContext1(DbContextOptions<TestDbContext1> options): base(options)
        {
        }

        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
