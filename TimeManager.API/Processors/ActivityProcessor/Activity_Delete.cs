using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Processors.ActivityProcessor.Interfaces;

namespace TimeManager.API.Processors.ActivityProcessor
{
    public class Activity_Delete : Processor, IActivity_Delete
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

                IActivity_GetAll Activity_GetAll = new Activity_GetAll(_context);
                return await Activity_GetAll.Get();
            }
            catch (Exception ex)
            {
                response = new Response<List<Activity>>(ex, "Whoops, something went wrong");
                return response;
            }

        }
    }
}
