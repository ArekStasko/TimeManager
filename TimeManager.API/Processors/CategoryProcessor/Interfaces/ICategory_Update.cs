using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;
using TimeManager.API.Data.Response;

namespace TimeManager.API.Processors.CategoryProcessor.Interfaces
{
    public interface ICategory_Update
    {
        public Task<ActionResult<Response<List<Category>>>> Update(Category category);
    }
}
