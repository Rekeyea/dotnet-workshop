namespace Dtos;

#region Product
public record ProductDto(string Name, string Description, decimal Value);
public record CreateProductDto(string Name, string Description, decimal Value) : ProductDto(Name, Description, Value);
public record ProductResponseDto(long Id, string Name, string Description, decimal Value): ProductDto(Name, Description, Value);
#endregion

#region Client
public record ClientDto(string Name, string Surname);
public record CreateClientDto(string Name, string Surname, List<long> Products) : ClientDto(Name, Surname);
public record UpdateClientDto(string Name, string Surname, List<long> Products) : ClientDto(Name, Surname);
public record ClientResponse(long Id, string Name, string Surname, IEnumerable<ProductResponseDto> Products) : ClientDto(Name, Surname);
#endregion


#region Auth
public record RegisterModel(string Email, string Password);
public record RegisterResponse(string Id, string UserName);
public record LoginModel(string Email, string Password);
public record LoginResponse(string Token);
#endregion