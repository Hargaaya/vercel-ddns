namespace vercel_ddns_backend.Models;

public record VercelGetResponse
{
    public DnsRecord[] records { get; set; }
    public Pagination pagination { get; set; }
}

public class Pagination
{
     public int count { get; set; }
     public string next { get; set; }
     public Int64 prev { get; set; }
}