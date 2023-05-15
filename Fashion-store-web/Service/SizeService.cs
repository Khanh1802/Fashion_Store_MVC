using Fashion_store_web.Dtos.Sizes;
using Fashion_store_web.Options;
using Microsoft.Extensions.Options;

namespace Fashion_store_web.Service
{
    public class SizeService : ISizeService
    {
        private readonly HttpClient _httpClient;
        private readonly OptionsSize _options;

        public SizeService(HttpClient httpClient, IOptions<OptionsSize> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<SizeDto> CreateAsync(CreateSizeDto item)
        {
            var create = await _httpClient.PostAsJsonAsync($"{_options.CreateSize}", item);
            create.EnsureSuccessStatusCode();
            return await create.Content.ReadFromJsonAsync<SizeDto>();
        }

        public async Task DeleteAsync(Guid key)
        {
            var delete = await _httpClient.DeleteAsync($"{_options.DeleteSize}/{key}");
            delete.EnsureSuccessStatusCode();
        }

        public async Task<SizeDto> GetById(Guid key)
        {
            var size = await _httpClient.GetAsync($"{_options.GetById}/{key}");
            size.EnsureSuccessStatusCode();
            return await size.Content.ReadFromJsonAsync<SizeDto>();
        }

        public async Task<List<SizeDto>> GetListAsync()
        {
            var sizes = await _httpClient.GetAsync($"{_options.GetSize}");
            sizes.EnsureSuccessStatusCode();
            // Read 
            //var content = await sizes.Content.ReadAsStringAsync();
            //var json = JsonConvert.DeserializeObject<GenericResponse<SizeDto>>(content);
            return (await sizes.Content.ReadFromJsonAsync<GenericResponse<SizeDto>>()).Items ?? new();
        }

        public async Task<SizeDto> UpdateAsync(UpdateSizeDto item)
        {
            var size = await _httpClient.PutAsJsonAsync($"{_options.UpdateSize}/{item.Id}", item);
            size.EnsureSuccessStatusCode();
            return await size.Content.ReadFromJsonAsync<SizeDto>();
        }
    }
}
