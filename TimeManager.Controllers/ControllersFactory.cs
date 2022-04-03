using TimeManager.Controllers.activityControllers;
using TimeManager.Controllers.categoryControllers;

namespace TimeManager.Controllers
{
    public static class ControllersFactory
    {
        public static IActivityControllers GetActivityControllersInstance(this IView view) => new ActivityControllers();
        public static ICategoryControllers GetCategoryControllersInstance(this IView view) => new CategoryControllers();
    }
}