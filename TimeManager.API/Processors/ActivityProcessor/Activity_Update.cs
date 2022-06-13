using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Processors.ActivityProcessor.Interfaces;

namespace TimeManager.API.Processors.ActivityProcessor
{
    public class Activity_Update : Processor
    {
        public Activity_Update(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<Activity>>>> Update(Activity activity)
        {
            Response<List<Activity>> response;

            try
            {
                var act = _context.Activities.Single(act => act.Id == activity.Id);
                _context.Activities.Remove(act);

                IActivity_Add Activity_Add = new Activity_Add(_context);
                return await Activity_Add.Post(activity);
            }
            catch (Exception ex)
            {
                response = new Response<List<Activity>>(ex, "Whoops, something went wrong");
                return response;
            }


        }
    }
}
