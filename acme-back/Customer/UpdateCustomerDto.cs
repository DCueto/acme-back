namespace acme_back.Customer;

public class UpdateCustomerDto
{
    public string Name { get; set; } = null!;
    public DateTime EntryDate { get; set; }
}