using TimeManager.API.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Controllers.ActivityControllers
{
    public interface IActivityController
    {
        public Task<ActionResult<Response<List<Activity>>>> Get();
        public Task<ActionResult<Response<IActivity>>> GetById(int id);
        public Task<ActionResult<Response<List<IActivity>>>> GetByCategory(int categoryId);
        public Task<ActionResult<Response<List<IActivity>>>> Add(Activity activit);
        public Task<ActionResult<Response<List<IActivity>>>> Delete(int Id);
        public Task<ActionResult<Response<List<IActivity>>>> Update(Activity activity);
    }
}
