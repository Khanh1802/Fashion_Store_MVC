using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Models
{
    public class Category
    {
        [Required]
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        [Required]        
        public int Order { get; set; }
        public string Slug { get; set; }
    }
}
