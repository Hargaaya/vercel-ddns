using System.ComponentModel.DataAnnotations;

namespace vercel_ddns_backend.Models;

public record DnsRecord(
    string Id,
    string Slug,
    [Required] string Name,
    [Required] string Type,
    [Required] string Value,
    string? MxPriority,
    string? Priority,
    string Creator,
    int? Created,
    int? Updated,
    int? CreatedAt,
    int? UpdatedAt
    );