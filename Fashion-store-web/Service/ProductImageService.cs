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

        public async Task<ProductImageDto> CreateAsync(CreateProductImageDto item)
        {
            var create = await _httpClient.PostAsJsonAsync($"{_options.CreateProductImage}", item);
            create.EnsureSuccessStatusCode();
            return await create.Content.ReadFromJsonAsync<ProductImageDto>();
        }

        public async Task DeleteAsync(Guid key)
        {
            var delete = await _httpClient.DeleteAsync($"{_options.DeleteProductImage}/{key}");
            delete.EnsureSuccessStatusCode();
        }

        public async Task<ProductImageDto> GetById(Guid key)
        {
            var productImage = await _httpClient.GetAsync($"{_options.GetById}/{key}");
            productImage.EnsureSuccessStatusCode();
            return await productImage.Content.ReadFromJsonAsync<ProductImageDto>();
        }

        public async Task<List<ProductImageDto>> GetListAsync()
        {
            var productImages = await _httpClient.GetAsync($"{_options.GetProductImage}");
            productImages.EnsureSuccessStatusCode();
            return (await productImages.Content.ReadFromJsonAsync<GenericResponse<ProductImageDto>>()).Items;
        }

        public async Task<ProductImageDto> UpdateAsync(UpdateProductImageDto item)
        {
            var update = await _httpClient.PutAsJsonAsync($"{_options.UpdateProductImage}/{item.Id}", item);
            update.EnsureSuccessStatusCode();
            return await update.Content.ReadFromJsonAsync<ProductImageDto>();
        }
    }
}
