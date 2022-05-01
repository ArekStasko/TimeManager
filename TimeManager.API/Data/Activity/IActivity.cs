namespace TimeManager.API.Data
{
    public interface IActivity
    {
        public int Id { get; set; }
        public string ActName { get; set; }
        public string ActDesc { get; set; }
        public string Category { get; set; }
    }
}
