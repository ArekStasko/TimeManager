using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_Update : Auth_Processor, IActivity_Update
    {
        public vwActivityCategory_Update(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Update(Request<Activity> request)
        {
            Response<List<vwActivityCategory>> response;

            try
            {
                var act = _context.Activities.Single(act => act.Id == request.Data.Id);
                _context.Activities.Remove(act);

                IActivity_Add activity_Add = new Activity_Add(_context);
                return await activity_Add.Post(request);
            }
            catch (Exception ex)
            {
                response = new Response<List<vwActivityCategory>>(ex, "Whoops, something went wrong");
                return response;
            }


        }
    }
}
