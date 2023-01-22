namespace vercel_ddns_backend.Models;

public record Error
{
    public string? Code { get; set; }
    public string? Message { get; set; }
}