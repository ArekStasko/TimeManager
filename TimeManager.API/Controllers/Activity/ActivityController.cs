﻿using Microsoft.AspNetCore.Mvc;
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
            var Activity_GetAll = new Activity_GetAll(_context);
            var activities = await Activity_GetAll.Get();
            return Ok(activities);
        }

        [HttpGet(Name = "GetActivityById")]
        public async Task<ActionResult<Response<IActivity>>> GetById(int id)
        {
            var Activity_GetById = new Activity_GetById(_context);
            return Ok(await Activity_GetById.Get(id));
        }

        [HttpGet(Name = "GetActivitiesByCategory")]
        public async Task<ActionResult<Response<List<IActivity>>>> GetByCategory(int categoryId)
        {
            var Activity_GetByCategory = new Activity_GetByCategory(_context);  
            return Ok(await Activity_GetByCategory.Get(categoryId));
        }

        [HttpPost(Name = "AddActivity")]
        public async Task<ActionResult<Response<List<IActivity>>>> Add(Activity activity)
        {
            var Activity_Add = new Activity_Add(_context);
            return Ok(Activity_Add.Post(activity));          
        }

        [HttpDelete(Name = "DeleteActivity")]
        public async Task<ActionResult<Response<List<IActivity>>>> Delete(int Id)
        {
            var Activity_Delete = new Activity_Delete(_context);
            return Ok(Activity_Delete.Delete(Id));
        }

        [HttpPost(Name = "UpdateActivity")]
        public async Task<ActionResult<Response<List<IActivity>>>> Update(Activity activity)
        {
            var Activity_Update = new Activity_Update(_context);
            return Ok(Activity_Update.Update(activity));
        }
    }
}
