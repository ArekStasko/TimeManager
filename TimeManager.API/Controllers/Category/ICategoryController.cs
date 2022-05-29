using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;

namespace TimeManager.API.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<List<ICategory>>> Get();
        public Task<ActionResult<List<ICategory>>> Add(Category category);
        public void Delete(string category);
        public void Update(string category);
    }
}
