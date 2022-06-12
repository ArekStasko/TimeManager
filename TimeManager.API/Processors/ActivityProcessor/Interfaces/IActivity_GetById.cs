using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.ActivityProcessor.Interfaces
{
    public interface IActivity_GetById
    {
        public Task<ActionResult<Response<IActivity>>> Get(int id);
    }
}
