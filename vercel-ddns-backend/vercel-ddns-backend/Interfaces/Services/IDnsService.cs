using vercel_ddns_backend.Models;

namespace vercel_ddns_backend.Interfaces.Services;

public interface IDnsService
{ 
    Task<IEnumerable<DnsRecord>?> GetRecords(string domainName);
    Task<DnsRecord?> UpdateRecord(string domainName, DnsRecord recordData);
    Task<bool> DeleteRecord(string domainName, string dnsName);
}