namespace vercel_ddns_backend.Models;

public class DnsRecord
{
    public string Id { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public string? MxPriority { get; set; }
    public string? Priority { get; set; }
    public string Creator { get; set; }
    public Int64 Created { get; set; }
    public Int64 Updated { get; set; }
    public Int64 CreatedAt { get; set; }
    public Int64 UpdatedAt { get; set; }
    public int Ttl { get; set; }
}