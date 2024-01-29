namespace RealEstatePortal.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services) =>
        services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

    public static IApplicationBuilder UseSwaggerWithUi(this WebApplication app)
    {
        return app
            .UseSwagger()
            .UseSwaggerUI();
    }
}
