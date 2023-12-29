using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class JwtSettings
{
    private const string SettingsSectionName = "JwtSettings"; 
    
    private readonly IConfiguration _configuration;
    public string Secret { get ; private set; }
    
    public string Issuer { get; private set; }
    
    public string Audience { get ; private set; }

    public JwtSettings(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public static JwtSettings FromConfiguration(IConfiguration configuration)
    {
        return new JwtSettings(configuration);
    }

    private void PopulateSettings()
    {
        IConfigurationSection section = this._configuration.GetSection(SettingsSectionName);
        
        Secret = section.GetSection("Secret")?.Value ?? throw new ArgumentNullException(nameof(Secret));
        Issuer = section.GetSection("Issuer")?.Value ?? throw new ArgumentNullException(nameof(Issuer));
        Audience = section.GetSection("Audience")?.Value ?? throw new ArgumentNullException(nameof(Audience));
        
    }
    
}