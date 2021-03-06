using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Delete : Auth_Processor, ICategory_Delete
    {
        public Category_Delete(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<vwCategory>>>> Delete(Request<int> request)
        {
            Response<List<vwCategory>> response;
            try
            {
                var category = _context.Categories.Single(c => c.Id == request.Data);
                _context.Categories.Remove(category);
                _context.SaveChanges();

                ICategory_Get Category_Get = new Category_Get(_context);
                return await Category_Get.Get(request.Token);
            }
            catch (Exception ex)
            {
                response = new Response<List<vwCategory>>(ex, "Whoops, something went wrong");
                return response;
            }

        }
    }
}
