using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class Activity_Add : Auth_Processor, IActivity_Add
    {

        public Activity_Add(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Post(Request<Activity> request)
        {
            Response<List<vwActivityCategory>> response;
            try
            {
                _context.Activities.Add(request.Data);
                _context.SaveChanges();

                IvwActivityCategory_GetAll vwActivityCategory_GetAll = new vwActivityCategory_GetAll(_context);
                return await vwActivityCategory_GetAll.Get(request.Token);
            }
            catch (Exception ex)
            {
                response = new Response<List<vwActivityCategory>>(ex, "Whoops, Something went wrong");
                return response;
            }

        }
    }
}
