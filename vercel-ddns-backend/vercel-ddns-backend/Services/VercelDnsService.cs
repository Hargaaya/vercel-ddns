using vercel_ddns_backend.Interfaces.Services;
using vercel_ddns_backend.Models;

namespace vercel_ddns_backend.Services;

public class VercelDnsService : IDnsService
{
    public Task<IEnumerable<DnsRecord>?> GetRecords(string domainName)
    {
        throw new NotImplementedException();
    }

    public Task<DnsRecord?> UpdateRecord(string domainName, DnsRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRecord(string domainName, string dnsName)
    {
        throw new NotImplementedException();
    }
}