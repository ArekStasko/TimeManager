using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

namespace TimeManager.API.Controllers.CategoryControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
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
    }
}
