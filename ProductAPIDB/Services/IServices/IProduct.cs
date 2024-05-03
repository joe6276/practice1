using ProductAPIDB.Models;

namespace ProductAPIDB.Services.IServices
{
    public interface IProduct
    {

        Task<string> addProduct(Product product);
        Task<string> removeProduct(Product product);

        Task<List<Product>> GetAllProducts();

        Task<Product> GetProductById(Guid productId);


        Task<string> updateProduct(Product product);
    }
}
