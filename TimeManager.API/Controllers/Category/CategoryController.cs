using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Processors.CategoryProcessor;

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
        public async Task<ActionResult<List<Category>>> Get()
        {
            var Category_Get = new Category_Get(_context);
            return Ok(await Category_Get.Get());
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<List<Category>>> Add(Category category)
        {
            var Category_Add = new Category_Add(_context);
            return Ok(await Category_Add.Post(category));
        }

        [HttpPost(Name = "DeleteCategory")]
        public async Task<ActionResult<List<Category>>> Delete(int Id)
        {
            var Category_Delete = new Category_Delete(_context);
            return Ok(Category_Delete.Delete(Id));
        }

        [HttpPost(Name = "UpdateCategory")]
        public async Task<ActionResult<List<Category>>> Update(Category category)
        {
            var Category_Update = new Category_Update(_context);
            return Ok(Category_Update.Update(category));
        }
    }
}
