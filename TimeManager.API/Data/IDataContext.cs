using Microsoft.EntityFrameworkCore;

namespace TimeManager.API.Data
{
    public interface IDataContext
    {
        public DbSet<vwActivityCategory> vwActivityCategory { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
