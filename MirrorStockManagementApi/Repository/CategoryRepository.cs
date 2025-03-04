using Microsoft.EntityFrameworkCore;
using MirrorStockManagementApi.Data;
using MirrorStockManagementApi.Models;
using MirrorStockManagementApi.Repository.IRepository;

namespace MirrorStockManagementApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _data;

        public CategoryRepository(ApplicationDbContext data)
        {
            _data = data;
        }
        public async Task<List<Category>> GetCategoryListAsync()
        {
            try
            {
                var categories = await _data.Categories.ToListAsync();

                return categories;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
