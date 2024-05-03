using Microsoft.EntityFrameworkCore;
using ProductAPIDB.Data;
using ProductAPIDB.Models;
using ProductAPIDB.Services.IServices;

namespace ProductAPIDB.Services
{
    public class ProductService : IProduct
    {

        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> addProduct(Product product)
        {
           _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return " Product Added Successfully";
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public Task<Product> GetProductById(Guid productId)
        {
            return _context.Products.Where(x=>x.Id==productId).FirstOrDefaultAsync();
        }

        public async Task<string> removeProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return " Product removed Successfully";
        }

        public async Task<string> updateProduct(Product product)
        {
            //_context.Products.Update(product);
            await _context.SaveChangesAsync();
            return " Product updated Successfully";
        }
    }
}
