namespace acme_back.Product;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task<int> CreateProduct(int customerId, Product product);
    Task<int> UpdateProduct(int id, Product product);
    Task<int> DeleteProduct(int id);
}