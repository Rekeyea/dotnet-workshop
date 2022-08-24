using Asp.Versioning.Builder;
using DataAccess;
using Dtos;
using Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Routing;

public static class ProductRouting
{
    public static WebApplication UseProductRoutes(this WebApplication app, ApiVersionSet versionSet)
    {
        var group = app.MapGroup("/products").RequireAuthorization();
        group
            .WithApiVersionSet(versionSet)
            .HasApiVersion(new Asp.Versioning.ApiVersion(1, 0));

        group.MapGet("", (ProductService ps) => Results.Ok(ps.GetProducts()));
        group.MapGet("/{id}", async (long id, ProductService ps) =>
        {
            try
            {
                var product = await ps.GetProductById(id);
                return Results.Ok(product);
            }
            catch
            {
                return Results.NotFound();
            }
        })
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        group.MapPost("", async (CreateProductDto p, ProductService ps) =>
        {
            try
            {
                var product = await ps.CreateProduct(p);
                return Results.Created($"/products/{product.Id}", product);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        return app;
    }
}