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
}
