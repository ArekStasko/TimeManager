using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;

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
        public async Task<ActionResult<List<IActivity>>> Get()
        {
            return Ok(await _context.Activities.ToListAsync());
        }

        [HttpGet(Name = "GetActivityById")]
        public async Task<ActionResult<IActivity>> GetById(int id)
        {
            var activities = await _context.Activities.ToListAsync();
            return Ok(activities.Single(act => act.Id == id));
        }

        [HttpGet(Name = "GetActivitiesByCategory")]
        public async Task<ActionResult<List<IActivity>>> GetByCategory(int categoryId)
        {
            var activities = await _context.Activities.ToListAsync();
            return Ok(activities.Where(act => act.CategoryId == categoryId));
        }

        [HttpPost(Name = "AddActivity")]
        public async Task<ActionResult<List<IActivity>>> Add(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();

            return Ok(await _context.Activities.ToListAsync());
        }

        [HttpDelete(Name = "DeleteActivity")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost(Name = "UpdateActivity")]
        public void Update(IActivity activity)
        {
            throw new NotImplementedException();
        }
    }
}
