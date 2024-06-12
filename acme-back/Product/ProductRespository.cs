using acme_back.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace acme_back.Product;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Product> GetProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product!;
    }

    public async Task<int> CreateProduct(int customerId, Product product)
    {
        // If product isn't related with any customer
        if(customerId > 0)
            product.CustomerId = customerId;
        
        _context.Add(product);
        await _context.SaveChangesAsync();
        
        return product.Id;
    }

    public async Task<int> UpdateProduct(int id, Product product)
    {
        var existingCustomer = await _context.Products.FindAsync(id);
        if (existingCustomer == null)
            return 0;
        
        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return product.Id;
    }

    public async Task<int> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return 0;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return product.Id;
    }
}