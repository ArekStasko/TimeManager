using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_GetById : Auth_Processor, IvwActivityCategory_GetById
    {
        public vwActivityCategory_GetById(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<vwActivityCategory>>> Get(Request<int> request)
        {
            Response<vwActivityCategory> response;
            try
            {
                var activities = await _context.vwActivityCategory.ToListAsync();
                var activity = activities.Single(act => act.Id == request.Data);
                
                response = new Response<vwActivityCategory>(activity);
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<vwActivityCategory>(ex, "Whoops, something went wrong");
                return response;
            }
          
        }

    }
}
