namespace Configuration.Models;

public record CorsConfiguration(string AllowedHosts);
public record JwtConfiguration(string ValidAudience, string ValidIssuer, string Secret);