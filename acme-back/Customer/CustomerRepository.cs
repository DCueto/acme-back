using acme_back.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace acme_back.Customer;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _context.Customers.ToListAsync();
    }
    
    public async Task<Customer> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        return customer!;
    }

    public async Task<int> CreateCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        
        return customer.Id;
    }

    public async Task<int> UpdateCustomer(int id, Customer customer)
    {
        var existingCustomer = await _context.Customers.FindAsync(id);
        if (existingCustomer == null)
            return 0;
        
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();

        return customer.Id;
    }
    
    public async Task<int> DeleteCustomer(int id)
        {
            
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                return 0;
            
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
    
}