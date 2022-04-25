using Microsoft.AspNetCore.Mvc;

namespace TimeManager.API.Controllers.Activity
{
    public class ActivityController : Controller, IActivityController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
