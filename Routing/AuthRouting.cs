using Asp.Versioning.Builder;
using Dtos;
using Services;

namespace Routing;

public static class AuthRouting
{
    public static WebApplication UseAuthRoutes(this WebApplication app, ApiVersionSet versionSet)
    {
        var group = app.MapGroup("/auth");

        group.MapPost("/register", async (RegisterModel model, AuthService authService) =>
        {
            try
            {
                var result = await authService.Register(model);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        group.MapPost("/login", async (LoginModel model, AuthService authService) =>
        {
            try
            {
                var result = await authService.Login(model);
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        return app;
    }
}