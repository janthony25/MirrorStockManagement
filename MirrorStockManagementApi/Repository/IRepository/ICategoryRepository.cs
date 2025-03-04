using MirrorStockManagementApi.Models;

namespace MirrorStockManagementApi.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoryListAsync();
    }
}
