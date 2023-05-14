using Fashion_store_web.Dtos.Sizes;

namespace Fashion_store_web.Service
{
    public interface ISizeService : IGenericService<SizeDto, CreateSizeDto, Guid, UpdateSizeDto>
    {
    }
}
