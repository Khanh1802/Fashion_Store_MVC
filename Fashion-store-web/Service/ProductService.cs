using Fashion_store_web.Dtos.Categories;
using Fashion_store_web.Dtos.Products;
using Fashion_store_web.Options;
using Microsoft.Extensions.Options;

namespace Fashion_store_web.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private OptionsProduct _options;

        public ProductService(HttpClient httpClient, IOptions<OptionsProduct> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public Task<ProductDto> CreateAsync(CreateProductDto category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid key)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetById(Guid key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetListAsync()
        {
            var categories = await _httpClient.GetAsync($"{_options.GetProduct}");
            categories.EnsureSuccessStatusCode();
            return (await categories.Content.ReadFromJsonAsync<GenericResponse<ProductDto>>()).Items ?? new();
        }

        public Task<ProductDto> UpdateAsync(UpdateProductDto category)
        {
            throw new NotImplementedException();
        }
    }
}
