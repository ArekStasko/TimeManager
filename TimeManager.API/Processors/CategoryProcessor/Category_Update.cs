using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Update : Processor
    {
        public Category_Update(DataContext context) : base(context) {}

        public async Task<ActionResult<List<Category>>> Update(Category category)
        {
            var cat = _context.Categories.Single(c => c.Id == category.Id);
            _context.Categories.Remove(cat);
            _context.Categories.Add(category);

            _context.SaveChanges();

            return await _context.Categories.ToListAsync();
        }

    }
}
