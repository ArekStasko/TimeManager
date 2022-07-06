using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Processors.vwActivityCategoryProcessor
{
    public class vwActivityCategory_GetByCategory : Processor, IvwActivityCategory_GetByCategory
    {
        public vwActivityCategory_GetByCategory(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Get(int id)
        {
            Response<List<vwActivityCategory>> response;

            try
            {
                var activities = await _context.vwActivityCategory.ToListAsync();
                activities = activities.Where(activity => activity.CategoryId == id).ToList();

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
