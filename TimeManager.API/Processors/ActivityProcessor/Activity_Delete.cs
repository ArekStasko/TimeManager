using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.ActivityProcessors
{
    public class Activity_Delete : Processor
    {

        public Activity_Delete(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<Activity>>>> Delete(int Id)
        {
            Response<List<Activity>> response;
            try
            {
                var activity = _context.Activities.Single(act => act.Id == Id);
                _context.Activities.Remove(activity);
                _context.SaveChanges();

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
