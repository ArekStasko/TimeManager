using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Get : Processor, ICategory_Get
    {
        public Category_Get(DataContext context) : base(context) {}

        public async Task<ActionResult<Response<List<vwCategory>>>> Get()
        {
            Response<List<vwCategory>> response;
            try
            {
                var categories = await _context.vwCategories.ToListAsync();
                response = new Response<List<vwCategory>>(categories);

                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<vwCategory>>(ex, "Whoops, something went wrong");
                return response;
            }
        }
    }
}
