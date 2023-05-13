using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Dtos.Categories
{
    public class UpdateCategoryDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }
        [Required]
        public string Slug { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
