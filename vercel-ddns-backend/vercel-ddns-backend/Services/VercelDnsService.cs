using RestSharp;
using vercel_ddns_backend.Interfaces.Services;
using vercel_ddns_backend.Models;

namespace vercel_ddns_backend.Services;

public class VercelDnsService : IDnsService
{
    private const string VercelUrl = "https://api.vercel.com/v4/domains";
    private readonly RestClient _client;

    public VercelDnsService(IConfiguration config)
    {
        var apiKey = config.GetValue<string>("DnsApiKey");
        _client = new RestClient(VercelUrl)
            .AddDefaultHeader(KnownHeaders.Authorization, $"Bearer {apiKey}");
    }
    public async Task<IEnumerable<DnsRecord>?> GetRecords(string domain)
    {
        var resp = await _client.GetJsonAsync<VercelGetResponse>($"/{domain}/records");
        
        return resp?.records;
    }

    public Task<DnsRecord?> CreateRecord(string domain, DnsRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<DnsRecord?> UpdateRecord(string domain, DnsRecord record)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRecord(string domain, string dnsName)
    {
        throw new NotImplementedException();
    }
}