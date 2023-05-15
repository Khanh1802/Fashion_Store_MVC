using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Dtos.ProductImage
{
    public class CreateProductImageDto
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        public string Description { get; set; }
        [Required]
        public string Slug { get; set; }
    }
}
