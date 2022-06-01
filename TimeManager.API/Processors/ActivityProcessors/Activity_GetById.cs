using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_GetById : Activity_Processor
    {
        public Activity_GetById(DataContext context) : base(context) { }

        public async Task<ActionResult<IActivity>> Get(int id)
        {
            var activities = await _context.Activities.ToListAsync();
            return activities.Single(act => act.Id == id);
        }

    }
}
