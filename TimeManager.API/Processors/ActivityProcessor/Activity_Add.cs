using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Processors.ActivityProcessor.Interfaces;


namespace TimeManager.API.Processors.ActivityProcessor
{
    public class Activity_Add : Processor, IActivity_Add
    {

        public Activity_Add(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<Activity>>>> Post(Activity activity)
        {
            Response<List<Activity>> response;
            try
            {
                _context.Activities.Add(activity);
                _context.SaveChanges();

                IActivity_GetAll Activity_GetAll = new Activity_GetAll(_context);
                return await Activity_GetAll.Get();
            }
            catch (Exception ex)
            {
                response = new Response<List<Activity>>(ex, "Whoops, Something went wrong");
                return response;
            }

        }
    }
}
