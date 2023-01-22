namespace vercel_ddns_backend.Models.Get;

public record VercelGetResponse
{
    public DnsRecord[]? Records { get; set; }
    public Pagination? Pagination { get; set; }
    public Error? Error { get; set; }
}

public record Pagination
{
     public int Count { get; set; }
     public string Next { get; set; } = string.Empty;
     public long Prev { get; set; }
}