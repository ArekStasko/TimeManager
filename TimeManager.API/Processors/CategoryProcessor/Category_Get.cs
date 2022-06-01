using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Processors.CategoryProcessor
{
    public class Category_Get : Processor
    {
        public Category_Get(DataContext context) : base(context) {}

        public async Task<ActionResult<List<Category>>> Get()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
