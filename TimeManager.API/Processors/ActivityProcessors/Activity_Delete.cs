using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_Delete : Activity_Processor
    {

        public Activity_Delete(DataContext context) : base(context) { }

        public async Task<ActionResult<List<Activity>>> Delete(int Id)
        {
            var activity = _context.Activities.Single(act => act.Id == Id);
            _context.Activities.Remove(activity);
            _context.SaveChanges();
            return await _context.Activities.ToListAsync();
        }
    }
}
