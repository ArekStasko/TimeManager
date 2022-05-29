using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;

namespace TimeManager.API.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<List<ICategory>>> Get();
        public void Add(string category);
        public void Delete(string category);
        public void Update(string category);
    }
}
