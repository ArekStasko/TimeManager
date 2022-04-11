using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeManager.DataAccess.models.category;

namespace TimeManager.Controllers.categoryControllers
{
    public class CategoryControllers : DbContext, ICategoryControllers
    {
        public CategoryControllers(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> categories { get; set; }

    }
}
