using System.ComponentModel.DataAnnotations;

namespace acme_back.Product;

public class Product
{
    public int Id { get; set; }
    
    [StringLength(50)]
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    // Optional foreign key and reference navigation to principal
    public int? CustomerId { get; set; }
    public Customer.Customer? Customer { get; set; }
}