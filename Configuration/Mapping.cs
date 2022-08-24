using Dtos;
using Entities;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Configuration;

public static class MappingConfiguration
{
    public static void AddMapping(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;

        typeAdapterConfig.ForType<CreateProductDto, Product>();
        typeAdapterConfig.ForType<CreateClientDto, Client>();
        typeAdapterConfig.ForType<IdentityUser, RegisterResponse>();
        typeAdapterConfig.ForType<Product, ProductResponseDto>();
        typeAdapterConfig.ForType<Client, ClientResponse>();
    }
}