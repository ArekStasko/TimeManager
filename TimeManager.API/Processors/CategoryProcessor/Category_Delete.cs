using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Delete : Processor
    {
        public Category_Delete(DataContext context) : base(context) { }

        public async Task<ActionResult<List<Category>>> Delete(int id)
        {
            var category = _context.Categories.Single(c => c.Id == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return await _context.Categories.ToListAsync();
        }
    }
}
