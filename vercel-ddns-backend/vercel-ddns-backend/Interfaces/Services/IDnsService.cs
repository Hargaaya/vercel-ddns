using vercel_ddns_backend.Models;

namespace vercel_ddns_backend.Interfaces.Services;

public interface IDnsService
{ 
    Task<IEnumerable<DnsRecord>?> GetRecords(string domain);
    Task<DnsRecord?> CreateRecord(string domain, DnsRecord record);
    Task<DnsRecord?> UpdateRecord(string domain, DnsRecord record);
    Task<bool> DeleteRecord(string domain, string dnsName);
}