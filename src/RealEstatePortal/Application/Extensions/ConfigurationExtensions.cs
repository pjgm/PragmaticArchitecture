namespace RealEstatePortal.Application.Extensions;

public static class ConfigurationExtensions
{
    public static T GetSection<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        var section = configuration.GetSection(sectionName);
        return (section.Exists() ? section.Get<T>() : new T()) ?? throw new InvalidOperationException();
    }
}
