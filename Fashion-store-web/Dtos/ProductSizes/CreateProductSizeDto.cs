using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Dtos.ProductSizes
{
    public class CreateProductSizeDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
