using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_GetAll : Processor, IvwActivityCategory_GetAll
    {
        public vwActivityCategory_GetAll(DataContext context) : base(context) { }
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Get()
        {
            Response<List<vwActivityCategory>> response;
            try
            {
                var activities = await _context.vwActivityCategory.ToListAsync();
                response = new Response<List<vwActivityCategory>>(activities);
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<vwActivityCategory>>(ex, "Whoops, something went wrong");
                return response;
            }
        }
    }
}
