namespace TimeManager.API.Data
{
    public interface IActivity
    {
        public int Id { get; }
        public string ActName { get; }
        public string ActDesc { get; }
        public string Category { get; }
    }
}
