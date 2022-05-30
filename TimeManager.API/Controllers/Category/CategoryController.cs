using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Controllers.CategoryControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase, ICategoryController
    {
        private readonly DataContext _context;
        public CategoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<ActionResult<List<ICategory>>> Get()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<List<ICategory>>> Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPost(Name = "DeleteCategory")]
        public async Task<ActionResult<List<ICategory>>> Delete(int Id)
        {
            var category = _context.Categories.Single(c => c.Id == Id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPost(Name = "UpdateCategory")]
        public async Task<ActionResult<List<ICategory>>> Update(Category category)
        {
            var cat = _context.Categories.Single(c => c.Id == category.Id);
            _context.Categories.Remove(cat);
            _context.Categories.Add(category);

            _context.SaveChanges();

            return Ok(await _context.Categories.ToListAsync());
        }
    }
}
