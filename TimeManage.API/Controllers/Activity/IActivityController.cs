using TimeManager.API.Data;

namespace TimeManager.API.Controllers.ActivityControllers
{
    public interface IActivityController
    {
        public List<IActivity> GetAll();
        public IActivity GetById(int id);
        public List<IActivity> GetByCat(string catName);
        public void Add();
        public void Delete(int id);
        public void Update(IActivity activity);
    }
}
