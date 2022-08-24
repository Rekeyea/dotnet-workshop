using Entities;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Configuration;

public static class OdataConfiguration{
    public static IEdmModel BuildEdmModel(){
        var builder = new ODataConventionModelBuilder();
        builder.EnableLowerCamelCase();
        builder.EntitySet<Product>("Products");
        builder.EntitySet<Client>("Clients");
        return builder.GetEdmModel();
    }
}