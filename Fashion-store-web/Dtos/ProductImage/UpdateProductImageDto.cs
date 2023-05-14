using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Dtos.ProductImage
{
    public class UpdateProductImageDto
    {
        public Guid? Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        public string Description { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public bool IsDefault { get; set; }
    }
}
