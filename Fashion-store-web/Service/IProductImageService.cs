using Fashion_store_web.Dtos.ProductImage;

namespace Fashion_store_web.Service
{
    public interface IProductImageService : IGenericService<ProductImageDto, CreateProductImageDto, Guid, UpdateProductImageDto>
    {
    }
}
