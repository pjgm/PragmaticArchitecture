using RealEstatePortal.Api.Extensions;

namespace RealEstatePortal.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapAllEndpoints();

        app.Run();
    }
}
