using System.Text.Json.Serialization;

namespace vercel_ddns_backend.Models.Post;

public record VercelPostRequest
{
    
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Type Type { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;
}

public enum Type
{
    A,
    AAAA,
    ALIAS,
    CAA,
    CNAME,
    MX,
    NS,
    SRV,
    TXT
}