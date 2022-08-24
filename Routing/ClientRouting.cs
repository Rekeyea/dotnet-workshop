using Asp.Versioning.Builder;
using DataAccess;
using Dtos;
using Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Routing;

public static class ClientRouting
{
    public static WebApplication UseClientRoutes(this WebApplication app, ApiVersionSet versionSet)
    {
        var group = app.MapGroup("/clients").RequireAuthorization();
        group
            .WithApiVersionSet(versionSet)
            .HasApiVersion(new Asp.Versioning.ApiVersion(1, 0));

        group.MapGet("", (ClientService cs) => Results.Ok(cs.GetClients()));

        group.MapGet("/{id}", async (long id, ClientService cs) =>
        {
            try
            {
                var client = await cs.GetClientById(id);
                return Results.Ok(client);
            }
            catch
            {
                return Results.NotFound();
            }
        });
        group.MapPost("", async (CreateClientDto c, ClientService cs) =>
        {
            try
            {
                var client = await cs.CreateClient(c);
                return Results.Created($"/clients/{client.Id}", client);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
        group.MapPut("/{id}", async (long id, UpdateClientDto c, ClientService ps) =>
        {
            try
            {
                var client = await ps.UpdateClient(id, c);
                return Results.Ok(client);
            }
            catch (ArgumentException)
            {
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
        return app;
    }
}