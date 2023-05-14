using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Dtos.Products
{
    public class UpdateProductDto
    {
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
