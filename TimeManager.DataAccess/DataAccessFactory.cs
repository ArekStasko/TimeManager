using TimeManager.DataAccess.models.activity;
using TimeManager.DataAccess.models.category;
using TimeManager.DataAccess.services.activityServices;
using TimeManager.DataAccess.services.categoryServices;

namespace TimeManager.DataAccess
{
    public static class DataAccessFactory
    {
        public static IActivity GetActivityInstance() => new Activity();
        public static ICategory GetCategoryInstance() => new Category();
        public static IActivityServices GetActivityServicesInstance() => new ActivityServices();
        public static ICategoryServices GetCategoryServicesInstance() => new CategoryServices();
    }
}