using System.ComponentModel.DataAnnotations;

namespace TimeManager.API.Data
{
    public class Category : ICategory
    {
        [Key]
        public int Id { get; set; }
        public string CatName { get; set; }
    }
}
