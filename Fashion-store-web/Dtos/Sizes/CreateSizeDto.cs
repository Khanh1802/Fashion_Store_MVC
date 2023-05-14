using System.ComponentModel.DataAnnotations;

namespace Fashion_store_web.Dtos.Sizes
{
    public class CreateSizeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
