using Microsoft.Extensions.Configuration;
using RealEstatePortal.Application.Configuration;
using Testcontainers.PostgreSql;

var configurationManager = new ConfigurationManager();

configurationManager.AddJsonFile("appsettings.Development.json");

var databaseConfig = configurationManager.GetSection(DatabaseOptions.SectionName);

var databaseOptions = databaseConfig.Get<DatabaseOptions>() ?? throw new InvalidOperationException();

var postgresContainer = new PostgreSqlBuilder()
    .WithUsername(databaseOptions.Username)
    .WithPassword(databaseOptions.Password)
    .WithPortBinding(databaseOptions.Port, databaseOptions.Port)
    .Build();

await postgresContainer.StartAsync();

Console.WriteLine("Local Development infrastructure is running. Press Enter to exit...");
Console.ReadLine();
