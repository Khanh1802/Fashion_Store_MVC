using Fashion_store_web.Dtos.ProductImage;
using Fashion_store_web.Dtos.ProductSizes;
using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Dtos.Products
{
    public class CreateProductDto
    {
        public Guid CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        public string Description { get; set; }

        [Required]
        public string Slug { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public List<CreateProductSizeDto> Sizes { get; set; }
        [Required]
        public List<ImageDto> Images { get; set; }
    }
}
