using TimeManager.DataAccess.models.activity;
using TimeManager.DataAccess.models.category;

namespace TimeManager.DataAccess
{
    public static class DataAccessFactory
    {
        public static IActivity GetActivityInstance() => new Activity();
        public static ICategory GetCategoryInstance() => new Category();
    }
}