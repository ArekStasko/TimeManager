namespace TimeManager.API.Data
{
    public class Activity : IActivity
    {
        public int Id { get; }
        public string ActName { get; }
        public string ActDesc { get; }
        public string Category { get; }
    }
}
