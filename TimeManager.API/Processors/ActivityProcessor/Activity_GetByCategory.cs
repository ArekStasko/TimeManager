using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public class Activity_GetByCategory : Processor, IActivity_GetByCategory
    {
        public Activity_GetByCategory(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<Activity>>>> Get(int id)
        {
            Response<List<Activity>> response;

            try
            {
                var activities = await _context.Activities.ToListAsync();
                activities = activities.Where(activity => activity.CategoryId == id).ToList();

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
