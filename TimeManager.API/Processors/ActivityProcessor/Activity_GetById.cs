using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_GetById : Processor
    {
        public Activity_GetById(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<IActivity>>> Get(int id)
        {
            Response<IActivity> response;
            try
            {
                var activities = await _context.Activities.ToListAsync();
                var activity = activities.Single(act => act.Id == id);
                
                response = new Response<IActivity>(activity);
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<IActivity>(ex, "Whoops, something went wrong");
                return response;
            }
          
        }

    }
}
