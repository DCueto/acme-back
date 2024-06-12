using acme_back.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace acme_back.Customer;
public interface ICustomerRepository
{
    Task<List<Customer>> GetAllCustomers();
    Task<Customer> GetCustomerById(int customerId);
    Task<int> CreateCustomer(Customer customer);
    Task<int> UpdateCustomer(int customerId, Customer customer);
    Task<int> DeleteCustomer(int customerId);
}