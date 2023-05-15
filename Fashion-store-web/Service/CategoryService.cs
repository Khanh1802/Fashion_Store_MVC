using Fashion_store_web.Dtos.Categories;
using Fashion_store_web.Options;
using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fashion_store_web.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly OptionsCategory _options;

        public CategoryService(HttpClient httpClient, IOptions<OptionsCategory> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto item)
        {
            var create = await _httpClient.PostAsJsonAsync($"{_options.CreateCategory}", item);
            create.EnsureSuccessStatusCode();
            return (await create.Content.ReadFromJsonAsync<CategoryDto>());
        }

        public async Task DeleteAsync(Guid key)
        {
            var delete = await _httpClient.DeleteAsync($"{_options.DeleteCategory}/{key}");
            delete.EnsureSuccessStatusCode();
        }

        public async Task<List<CategoryDto>> GetListAsync()
        {
            var categories = await _httpClient.GetAsync($"{_options.GetCategory}");
            categories.EnsureSuccessStatusCode();
            return await categories.Content.ReadFromJsonAsync<List<CategoryDto>>() ?? new();
        }

        public async Task<CategoryDto> UpdateAsync(UpdateCategoryDto item)
        {
            var update = await _httpClient.PutAsJsonAsync($"{_options.UpdateCategory}/{item.Id}", item);
            update.EnsureSuccessStatusCode();
            var data = await update.Content.ReadFromJsonAsync<CategoryDto>();
            return data;
        }

        public async Task<CategoryDto> GetById(Guid id)
        {
            var data = await _httpClient.GetAsync($"{_options.GetById}/{id}");
            data.EnsureSuccessStatusCode();
            return await data.Content.ReadFromJsonAsync<CategoryDto>() ?? new();
        }
    }
}
