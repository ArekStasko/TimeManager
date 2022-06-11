using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<Response<List<Category>>>> Get();
        public Task<ActionResult<Response<List<Category>>>> Add(Category category);
        public Task<ActionResult<Response<List<Category>>>> Delete(int Id);
        public Task<ActionResult<Response<List<Category>>>> Update(Category category);
    }
}
