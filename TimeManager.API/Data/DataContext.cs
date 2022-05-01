using Microsoft.EntityFrameworkCore;

namespace TimeManager.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Activity> Activities { get; set; }
        
    }
}
