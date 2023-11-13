using ProductAPI.Enities;

namespace ProductAPI.Repositories;
public interface IProductRepository
{
    Task CreateProduct(Product product);
    Task<bool> DeleteProduct(string id);
    Task<Product> GetProduct(string id);
    Task<IEnumerable<Product>> GetProductByCategory(string categoryName);
    Task<IEnumerable<Product>> GetProducts();
    Task<bool> UpdateProduct(Product product);
}