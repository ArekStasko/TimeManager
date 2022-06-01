using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_GetAll : Activity_Processor
    {
        public Activity_GetAll(DataContext context) : base(context) { }
        public async Task<ActionResult<List<Activity>>> Get()
        {
            return await _context.Activities.ToListAsync();
        }
    }
}
