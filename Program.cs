using Configuration;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Routing;
using Configuration.Models;
using Asp.Versioning;
using Services;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.OData;

var builder = WebApplication.CreateBuilder(args);

var corsConfiguration = builder.Configuration.GetSection("CORS").Get<CorsConfiguration>();

if (corsConfiguration is null)
{
    throw new Exception("CORS Configuration cannot be empty");
}

builder.Services.AddMapping();
builder.Services.AddControllers().AddOData(opt => {
    opt.AddRouteComponents("odata", OdataConfiguration.BuildEdmModel());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddCors(options
    => options.AddPolicy("cors-policy",
        conf => conf
            .WithOrigins(corsConfiguration.AllowedHosts)
            .AllowAnyHeader()
            .AllowAnyMethod()));
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = ApiVersion.Default;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new HeaderApiVersionReader("X-Api-Version");
});

var connectionString = builder.Configuration.GetConnectionString("Default");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection String cannot be empty");
}

builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });


builder.AddAppAuthConfig();

builder.Services.AddTransient<AuthService>();
builder.Services.AddTransient<ClientService>();
builder.Services.AddTransient<ProductService>();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

var versionSet = app
    .NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1, 0))
    .HasApiVersion(new ApiVersion(2, 0))
    .ReportApiVersions()
    .Build();

app
    .UseAuthRoutes(versionSet)
    .UseProductRoutes(versionSet)
    .UseClientRoutes(versionSet);

app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapHealthChecks("/health");
    endpoints.MapControllers();
});
app.Run();
