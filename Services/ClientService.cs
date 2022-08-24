using DataAccess;
using Dtos;
using Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class ClientService
{
    public ClientService(AppDbContext db)
    {
        Db = db;
    }

    public AppDbContext Db { get; }

    public IQueryable<ClientResponse> GetClients()
    {
        return this.Db.Clients.Include(x => x.Products).Select(x => x.Adapt<ClientResponse>());
    }

    public async Task<ClientResponse> GetClientById(long id)
    {
        var client = await Db.Clients.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
        if (client is null)
        {
            throw new Exception("Client not found");
        }

        return client.Adapt<ClientResponse>();
    }

    public async Task<ClientResponse> CreateClient(CreateClientDto c)
    {
        var client = c.Adapt<Client>();
        client.Products = await Db.Products.Where(x => c.Products.Contains(x.Id)).ToListAsync();
        await Db.Clients.AddAsync(client);
        await Db.SaveChangesAsync();
        return client.Adapt<ClientResponse>();
    }


    public async Task<ClientResponse> UpdateClient(long clientId, UpdateClientDto c)
    {
        var client = await this.Db.Clients
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == clientId);
        if (client is null)
        {
            throw new ArgumentException("Client not found");
        }
        
        c.Adapt(client);
        client.Products = await this.Db.Products.Where(x => c.Products.Contains(x.Id)).ToListAsync();
        await Db.SaveChangesAsync();
        return client.Adapt<ClientResponse>();
    }
}