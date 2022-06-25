using TimeManager.API.Data;

namespace TimeManager.API.Processors.ActivityProcessor
{
    public static class ActivityProcessor_Factory
    {
        public static IActivity_Add GetActivity_Add(this DataContext _context) => new Activity_Add(_context);
        public static IActivity_Delete GetActivity_Delete(this DataContext _context) => new Activity_Delete(_context);
        public static IActivity_GetAll GetActivity_GetAll(this DataContext _context) => new Activity_GetAll(_context);
        public static IActivity_GetByCategory GetActivity_GetByCategory(this DataContext _context) => new Activity_GetByCategory(_context);
        public static IActivity_GetById GetActivity_GetById(this DataContext _context) => new Activity_GetById(_context);
        public static IActivity_Update GetActivity_Update(this DataContext _context) => new Activity_Update(_context);
    }
}
