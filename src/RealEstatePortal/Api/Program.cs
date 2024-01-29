using RealEstatePortal.Api.Extensions;
using RealEstatePortal.Application.Extensions;
using RealEstatePortal.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddConfigurationOptions(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplicationFeatures()
    .AddSwagger();

var app = builder.Build();

app.MapAllEndpoints();
app.UseSwaggerWithUi();

await app.RunMigrations(app.Configuration);

app.Run();

public interface IApiMarker { }
