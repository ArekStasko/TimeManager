using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor.Interfaces
{
    public interface ICategory_Delete
    {
        public Task<ActionResult<Response<List<Category>>>> Delete(int id);
    }
}
