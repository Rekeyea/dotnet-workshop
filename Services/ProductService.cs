using DataAccess;
using Dtos;
using Entities;
using Mapster;

namespace Services;

public class ProductService
{
    public ProductService(AppDbContext db)
    {
        Db = db;
    }

    public AppDbContext Db { get; }

    public IQueryable<Product> GetProducts()
    {
        return this.Db.Products;
    }

    public async Task<Product> GetProductById(long id)
    {
        var product = await Db.Products.FindAsync(id);
        if (product is null)
        {
            throw new Exception("Product not found");
        }

        return product;
    }

    public async Task<Product> CreateProduct(CreateProductDto p)
    {
        var product = p.Adapt<Product>();
        await Db.Products.AddAsync(product);
        await Db.SaveChangesAsync();
        return product;
    }
}