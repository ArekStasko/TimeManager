using Microsoft.AspNetCore.Mvc;

namespace TimeManager.API.Controllers.Category
{
    public class CategoryController : Controller, ICategoryController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
