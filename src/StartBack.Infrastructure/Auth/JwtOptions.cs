namespace StartBack.Infrastructure.Auth;

public class JwtOptions
{
    public string Issuer { get; set; } = "AEMZ-ERP";
    public string Audience { get; set; } = "AEMZ-ERP-Clients";
    public string Key { get; set; } = "CHANGE_ME_SUPER_SECRET_KEY_32CHARS_MIN";
    public int ExpireMinutes { get; set; } = 120;
    public int RefreshTokenExpireDays { get; set; } = 7;
}

