using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Processors.CategoryProcessor.Interfaces;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Delete : Processor, ICategory_Delete
    {
        public Category_Delete(DataContext context) : base(context) { }

        public async Task<ActionResult<Response<List<Category>>>> Delete(int id)
        {
            Response<List<Category>> response;
            try
            {
                var category = _context.Categories.Single(c => c.Id == id);
                _context.Categories.Remove(category);
                _context.SaveChanges();

                var categories = await _context.Categories.ToListAsync();
                response = new Response<List<Category>>(categories);
                return response;
            }
            catch (Exception ex)
            {
                response = new Response<List<Category>>(ex, "Whoops, something went wrong");
                return response;
            }

        }
    }
}
