namespace vercel_ddns_backend.Models.Patch;

public record VercelPatchResponse
{
    public long CreatedAt { get; set; }
    public string? Creator { get; set; }
    public string? Domain { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? RecordType { get; set; }
    public int Ttl { get; set; }
    public string? Type { get; set; }
    public string? Value { get; set; }
    public Error? Error { get; set; }
}