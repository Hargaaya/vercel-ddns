namespace vercel_ddns_backend.Models.Post;

public record VercelPostResponse
{
    public string? Uid { get; set; }
    public Error? Error { get; set; }
}