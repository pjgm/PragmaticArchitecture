using Npgsql;

namespace RealEstatePortal.Application.Configuration;

public class DatabaseOptions
{
    public const string SectionName = "database";

    public string DatabaseName { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 5432;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string SslMode { get; set; } = string.Empty;

    public bool RunMigrations { get; set; } = false;

    public string GetConnectionString()
    {
        var sslMode = Enum.Parse<SslMode>(SslMode, ignoreCase: true);
        return new NpgsqlConnectionStringBuilder
        {
            Host = Host,
            Database = DatabaseName,
            Port = Convert.ToInt32(Port),
            Username = Username,
            Password = Password,
            SslMode = sslMode
        }.ToString();
    }
}
