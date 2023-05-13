namespace Fashion_store_web.Service
{
    public interface IGenericService<TDto, in TCreate, in TKey, in TUpdate> where TDto : class
    {
        Task<List<TDto>> GetListAsync();
        Task<TDto> CreateAsync(TCreate category);
        Task DeleteAsync(TKey key);
        Task<TDto> UpdateAsync(TUpdate category);
        Task<TDto> GetById(TKey key);
    }
}
