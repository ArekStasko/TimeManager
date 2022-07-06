using TimeManager.API.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Controllers.vwActivityCategoryControllers
{
    public interface IActivityController
    {
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Get();
        public Task<ActionResult<Response<vwActivityCategory>>> GetById(int id);
        public Task<ActionResult<Response<List<vwActivityCategory>>>> GetByCategory(int categoryId);
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Add(Activity activity);
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Delete(int Id);
        public Task<ActionResult<Response<List<vwActivityCategory>>>> Update(Activity activity);
    }
}
