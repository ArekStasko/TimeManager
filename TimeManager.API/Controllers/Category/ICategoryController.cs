using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<Response<List<vwCategory>>>> Get();
        public Task<ActionResult<Response<List<vwCategory>>>> Add(Category category);
        public Task<ActionResult<Response<List<vwCategory>>>> Delete(int Id);
        public Task<ActionResult<Response<List<vwCategory>>>> Update(Category category);
    }
}
