using Microsoft.EntityFrameworkCore;
using ProductAPIDB.Data;
using ProductAPIDB.Models;
using ProductAPIDB.Services.IServices;

namespace ProductAPIDB.Services
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> addCategory(Category category)
        {
           //add
           _context.Categories.Add(category);
            //save
            await _context.SaveChangesAsync();
            return "Category Saved Successfully!!";
        }

        public async Task<List<Category>> listCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
