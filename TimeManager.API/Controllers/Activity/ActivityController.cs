using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data.Response;
using TimeManager.API.Data;
using TimeManager.API.Processors.ActivityProcessor;


namespace TimeManager.API.Controllers.ActivityControllers
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
        public async Task<ActionResult<Response<List<Activity>>>> Get()
        {
            IActivity_GetAll Activity_GetAll = ActivityProcessor_Factory.GetActivity_GetAll(_context);
            var activities = await Activity_GetAll.Get();
            return Ok(activities);
        }

        [HttpGet(Name = "GetActivityById")]
        public async Task<ActionResult<Response<IActivity>>> GetById(int id)
        {
            IActivity_GetById Activity_GetById = ActivityProcessor_Factory.GetActivity_GetById(_context);
            return Ok(await Activity_GetById.Get(id));
        }

        [HttpGet(Name = "GetActivitiesByCategory")]
        public async Task<ActionResult<Response<List<IActivity>>>> GetByCategory(int categoryId)
        {
            IActivity_GetByCategory Activity_GetByCategory = ActivityProcessor_Factory.GetActivity_GetByCategory(_context);
            return Ok(await Activity_GetByCategory.Get(categoryId));
        }

        [HttpPost(Name = "AddActivity")]
        public async Task<ActionResult<Response<List<IActivity>>>> Add(Activity activity)
        {
            IActivity_Add Activity_Add = ActivityProcessor_Factory.GetActivity_Add(_context);
            return Ok(Activity_Add.Post(activity));          
        }

        [HttpDelete(Name = "DeleteActivity")]
        public async Task<ActionResult<Response<List<IActivity>>>> Delete(int Id)
        {
            IActivity_Delete Activity_Delete = ActivityProcessor_Factory.GetActivity_Delete(_context);
            return Ok(Activity_Delete.Delete(Id));
        }

        [HttpPost(Name = "UpdateActivity")]
        public async Task<ActionResult<Response<List<IActivity>>>> Update(Activity activity)
        {
            IActivity_Update Activity_Update = ActivityProcessor_Factory.GetActivity_Update(_context);
            return Ok(Activity_Update.Update(activity));
        }
    }
}
