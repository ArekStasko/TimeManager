using System.ComponentModel.DataAnnotations;

namespace TimeManager.API.Data
{
    public class Activity : IActivity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
