using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Model
{
    public class TestDbContext3 : DbContext
    {
        public TestDbContext3(DbContextOptions<TestDbContext3> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
