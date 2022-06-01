using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_GetByCategory : Activity_Processor
    {
        public Activity_GetByCategory(DataContext context) : base(context) { }

        public async Task<ActionResult<List<Activity>>> Get(int id)
        {
            var activities = await _context.Activities.ToListAsync();
            return activities.Where(activity => activity.CategoryId == id).ToList();
        }
    }
}
