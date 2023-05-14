using Fashion_store_web.Dtos.ProductImage;
using Fashion_store_web.Options;
using Microsoft.Extensions.Options;

namespace Fashion_store_web.Service
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;
        private readonly OptionsProductImage _options;

        public ProductImageService(HttpClient httpClient, IOptions<OptionsProductImage> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public Task<ProductImageDto> CreateAsync(CreateProductImageDto category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid key)
        {
            throw new NotImplementedException();
        }

        public Task<ProductImageDto> GetById(Guid key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductImageDto>> GetListAsync()
        {
            var productImages = await _httpClient.GetAsync($"{_options.GetProductImage}");
            productImages.EnsureSuccessStatusCode();
            return (await productImages.Content.ReadFromJsonAsync<GenericResponse<ProductImageDto>>()).Items;
        }

        public Task<ProductImageDto> UpdateAsync(UpdateProductImageDto category)
        {
            throw new NotImplementedException();
        }
    }
}
