namespace vercel_ddns_backend.Models;

public record DnsRecord
{
    public string Id { get; set; } = String.Empty;
    public string Slug { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Type { get; set; } = String.Empty;
    public string Value { get; set; } = String.Empty;
    public string? MxPriority { get; set; }
    public string? Priority { get; set; }
    public string? Creator { get; set; }
    public long Created { get; set; }
    public long Updated { get; set; }
    public long CreatedAt { get; set; }
    public long UpdatedAt { get; set; }
    public int Ttl { get; set; }
}