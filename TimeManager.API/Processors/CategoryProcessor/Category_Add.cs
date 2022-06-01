using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Add : Processor
    {
        public Category_Add(DataContext context) : base(context) { }


        public async Task<ActionResult<List<Category>>> Post(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return await _context.Categories.ToListAsync();
        }
    }
}
