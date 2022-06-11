using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Update : Processor
    {
        public Category_Update(DataContext context) : base(context) {}

        public async Task<ActionResult<Response<List<Category>>>> Update(Category category)
        {

            Response<List<Category>> response;
            try
            {
                var cat = _context.Categories.Single(c => c.Id == category.Id);
                _context.Categories.Remove(cat);
                _context.Categories.Add(category);

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
