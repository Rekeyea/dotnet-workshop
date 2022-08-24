namespace Entities;

public class Client : Entity
{
    public Client()
    {
        this.Name = string.Empty;
        this.Surname = string.Empty;
        this.Products = new List<Product> { };
    }

    public string Name { get; set; }    

    public string Surname { get; set; }

    public IEnumerable<Product> Products { get; set; }
}