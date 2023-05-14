namespace Fashion_store_web.Dtos.ProductImage
{
    public class ProductImageDto
    {
        public Guid? Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public bool IsDefault { get; set; }
        public string Url { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
