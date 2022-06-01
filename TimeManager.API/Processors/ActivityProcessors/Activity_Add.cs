using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_Add : Activity_Processor
    {

        public Activity_Add(DataContext context) : base(context) { }

        public async Task<ActionResult<List<Activity>>> Post(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return await _context.Activities.ToListAsync();
        }
    }
}
