using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data.Response;
using TimeManager.API.Data;
using TimeManager.API.Processors.vwActivityCategoryProcessor;


namespace TimeManager.API.Controllers.vwActivityCategoryControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase, IActivityController
    {
        private readonly DataContext _context;
        public ActivityController(DataContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetActivities")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Get()
        {
            IvwActivityCategory_GetAll vwActivityCategory_GetAll = ActivityProcessor_Factory.GetvwActivityCategory_GetAll(_context);
            var activities = await vwActivityCategory_GetAll.Get();
            return Ok(activities);
        }

        [HttpGet(Name = "GetvwActivityCategoryById")]
        public async Task<ActionResult<Response<vwActivityCategory>>> GetById(int id)
        {
            IvwActivityCategory_GetById vwActivityCategory_GetById = ActivityProcessor_Factory.GetvwActivityCategory_GetById(_context);
            return Ok(await vwActivityCategory_GetById.Get(id));
        }

        [HttpGet(Name = "GetActivitiesByCategory")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> GetByCategory(int categoryId)
        {
            IvwActivityCategory_GetByCategory vwActivityCategory_GetByCategory = ActivityProcessor_Factory.GetvwActivityCategory_GetByCategory(_context);
            return Ok(await vwActivityCategory_GetByCategory.Get(categoryId));
        }

        [HttpPost(Name = "AddvwActivityCategory")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Add(Activity activity)
        {
            IActivity_Add vwActivityCategory_Add = ActivityProcessor_Factory.GetActivity_Add(_context);
            return Ok(vwActivityCategory_Add.Post(activity));          
        }

        [HttpDelete(Name = "DeletevwActivityCategory")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Delete(int Id)
        {
            IActivity_Delete vwActivityCategory_Delete = ActivityProcessor_Factory.GetActivity_Delete(_context);
            return Ok(vwActivityCategory_Delete.Delete(Id));
        }

        [HttpPost(Name = "UpdatevwActivityCategory")]
        public async Task<ActionResult<Response<List<vwActivityCategory>>>> Update(Activity activity)
        {
            IActivity_Update vwActivityCategory_Update = ActivityProcessor_Factory.GetActivity_Update(_context);
            return Ok(vwActivityCategory_Update.Update(activity));
        }
    }
}
