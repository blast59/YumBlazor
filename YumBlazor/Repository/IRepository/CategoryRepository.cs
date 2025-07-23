using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Category> CreateAsync (Category obj)
        {
            await _db.Category.AddAsync(obj);
            await _db.SaveChangesAsync();
            // Implementation for creating a category
            return obj; // Placeholder return
        }
        public async Task<Category> UpdateAsync(Category obj)
        {
            var obj1 = await _db.Category.FirstOrDefaultAsync(x => x.Id == obj.Id);
            if (obj1 != null)
            {
                obj1.Id = obj.Id;
                obj1.Name = obj.Name;
                await _db.SaveChangesAsync();
            }
            return obj; // Placeholder return
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Category.Remove(obj);
                return (await _db.SaveChangesAsync()) > 0;
                // Category not found
            }

            return true;
        }
        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(x => x.Id == id); // Add await to call
            return obj; // This will now return a Category or null
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }
    }
}
