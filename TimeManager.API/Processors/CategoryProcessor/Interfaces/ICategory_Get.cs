﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor.Interfaces
{
    public interface ICategory_Get
    {
        public Task<ActionResult<Response<List<Category>>>> Get();
    }
}