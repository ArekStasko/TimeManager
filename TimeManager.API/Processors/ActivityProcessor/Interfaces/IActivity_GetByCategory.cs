﻿using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.ActivityProcessor.Interfaces
{
    public interface IActivity_GetByCategory
    {
        public Task<ActionResult<Response<List<Activity>>>> Get(int id);
    }
}
