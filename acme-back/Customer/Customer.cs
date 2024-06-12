using System.ComponentModel.DataAnnotations;

namespace acme_back.Customer;

public class Customer
{

    public int Id { get; set; }
    [StringLength(50)]
    public string Name { get; set; } = null!;
    public DateTime EntryDate { get; set; }
    public ICollection<Product.Product> Products { get; } = new List<Product.Product>();
}