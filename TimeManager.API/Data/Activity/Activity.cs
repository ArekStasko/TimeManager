using System.ComponentModel.DataAnnotations;

namespace TimeManager.API.Data
{
    public class Activity : IActivity
    {
        [Key]
        public int Id { get; set; }
        public string ActName { get; set; }
        public string ActDesc { get; set; }
        public string Category { get; set; }
    }
}
