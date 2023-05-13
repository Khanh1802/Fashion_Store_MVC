using Fashion_store_web.Dtos.Categories;

namespace Fashion_store_web.Service
{
    public interface ICategoryService : IGenericService<CategoryDto, CreateCategoryDto, Guid, UpdateCategoryDto>
    {

    }
}
