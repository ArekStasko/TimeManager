﻿using TimeManager.API.Data;
using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data.Response;


namespace TimeManager.API.Controllers.ActivityControllers
{
    public interface IActivityController
    {
        public Task<ActionResult<Response<List<Activity>>>> Get();
        public Task<ActionResult<IActivity>> GetById(int id);
        public Task<ActionResult<List<IActivity>>> GetByCategory(int categoryId);
        public Task<ActionResult<List<IActivity>>> Add(Activity activit);
        public Task<ActionResult<List<IActivity>>> Delete(int Id);
        public Task<ActionResult<List<IActivity>>> Update(Activity activity);
    }
}
