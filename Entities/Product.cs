namespace Entities;

public class Product : Entity
{
    public Product()
    {
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.Clients = new List<Client>();
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Value { get; set; }

    public IEnumerable<Client> Clients { get; set; }
}