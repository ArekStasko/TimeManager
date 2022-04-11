using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeManager.DataAccess.models.activity;

namespace TimeManager.DataAccess.services.activityServices
{
    public class ActivityServices : DbContext, IActivityServices
    {

        public ActivityServices(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }
    }
}
