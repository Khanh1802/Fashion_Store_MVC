using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Dtos.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }
    }
}
