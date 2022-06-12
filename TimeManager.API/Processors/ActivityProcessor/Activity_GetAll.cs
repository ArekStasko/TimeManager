using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Processors.ActivityProcessor.Interfaces;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_GetAll : Processor, IActivity_GetAll
    {
        public Activity_GetAll(DataContext context) : base(context) { }
        public async Task<ActionResult<Response<List<Activity>>>> Get()
        {
            Response<List<Activity>> response;
            try
            {
                var activities = await _context.Activities.ToListAsync();
                response = new Response<List<Activity>>(activities);
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<Activity>>(ex, "Whoops, something went wrong");
                return response;
            }
        }
    }
}
