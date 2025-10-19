using Npgsql;

namespace RealEstatePortal.Application.Configuration;

public static class DatabaseOptionsExtensions
{
    public static string GetConnectionString(this DatabaseOptions options)
    {
        var sslMode = Enum.Parse<SslMode>(options.SslMode, ignoreCase: true);
        return new NpgsqlConnectionStringBuilder
        {
            Host = options.Host,
            Database = options.DatabaseName,
            Port = Convert.ToInt32(options.Port),
            Username = options.Username,
            Password = options.Password,
            SslMode = sslMode
        }.ToString();
    }
}