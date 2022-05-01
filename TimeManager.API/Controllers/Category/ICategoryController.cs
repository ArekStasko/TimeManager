using Microsoft.AspNetCore.Mvc;
using TimeManager.API.Data;

namespace TimeManager.API.Controllers.CategoryControllers
{
    public interface ICategoryController
    {
        public Task<ActionResult<List<ICategory>>> Get();
        public void Add(string catName);
        public void Delete(string catName);
        public void Update(string catName);
    }
}
