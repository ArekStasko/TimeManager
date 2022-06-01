using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_Update : Processor
    {
        public Activity_Update(DataContext context) : base(context) { }

        public async Task<ActionResult<List<Activity>>> Update(Activity activity)
        {
            var act = _context.Activities.Single(act => act.Id == activity.Id);
            _context.Activities.Remove(act);
            _context.Activities.Add(activity);

            _context.SaveChanges();

            return await _context.Activities.ToListAsync();
        }
    }
}
