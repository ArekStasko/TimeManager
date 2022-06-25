using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Processors.CategoryProcessor;
using TimeManager.API.Data.Response;

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
        public async Task<ActionResult<Response<List<Category>>>> Get()
        {
            ICategory_Get Category_Get = CategoryProcessor_Factory.GetCategory_Get(_context);
            return Ok(await Category_Get.Get());
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Add(Category category)
        {
            ICategory_Add Category_Add = CategoryProcessor_Factory.GetCategory_Add(_context);
            return Ok(await Category_Add.Post(category));
        }

        [HttpPost(Name = "DeleteCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Delete(int Id)
        {
            ICategory_Delete Category_Delete = CategoryProcessor_Factory.GetCategory_Delete(_context);
            return Ok(Category_Delete.Delete(Id));
        }

        [HttpPost(Name = "UpdateCategory")]
        public async Task<ActionResult<Response<List<Category>>>> Update(Category category)
        {
            ICategory_Update Category_Update = CategoryProcessor_Factory.GetCategory_Update(_context);
            return Ok(Category_Update.Update(category));
        }
    }
}
