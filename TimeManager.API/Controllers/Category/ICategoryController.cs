using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;

namespace TimeManager.API.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<List<Category>>> Get();
        public Task<ActionResult<List<Category>>> Add(Category category);
        public Task<ActionResult<List<Category>>> Delete(int Id);
        public Task<ActionResult<List<Category>>> Update(Category category);
    }
}
