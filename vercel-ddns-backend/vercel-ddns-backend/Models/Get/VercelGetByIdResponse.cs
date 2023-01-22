namespace vercel_ddns_backend.Models.Get;

public record VercelGetByIdResponse
{
    public long CreatedAt { get; set; }
    public string creator { get; set; }
    public string domain { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public int ttl { get; set; }
    public string value { get; set; }
    public string recordType { get; set; }
    public string? type { get; set; }
    public Error? Error { get; set; }
}