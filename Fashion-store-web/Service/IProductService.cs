using Fashion_store_web.Dtos.Products;

namespace Fashion_store_web.Service
{
    public interface IProductService : IGenericService<ProductDto,CreateProductDto,Guid,UpdateProductDto>
    {
    }
}
