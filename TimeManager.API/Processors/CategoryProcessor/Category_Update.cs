using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;
using TimeManager.API.Processors.CategoryProcessor.Interfaces;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Update : Processor, ICategory_Update
    {
        public Category_Update(DataContext context) : base(context) {}

        public async Task<ActionResult<Response<List<Category>>>> Update(Category category)
        {
            Response<List<Category>> response;

            try
            {
                var cat = _context.Categories.Single(c => c.Id == category.Id);
                _context.Categories.Remove(cat);

                ICategory_Add Category_Add = new Category_Add(_context);
                return await Category_Add.Post(category);
            }
            catch (Exception ex)
            {
                response = new Response<List<Category>>(ex, "Whoops, something went wrong");
                return response;
            }

        }

    }
}
