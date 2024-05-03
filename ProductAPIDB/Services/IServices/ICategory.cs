using ProductAPIDB.Models;

namespace ProductAPIDB.Services.IServices
{
    public interface ICategory
    {

        Task<string> addCategory(Category category);

        Task<List<Category>> listCategories();
    }
}
