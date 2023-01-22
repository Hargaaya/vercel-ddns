using System.Net;
using System.Text.Json;
using RestSharp;
using vercel_ddns_backend.Interfaces.Services;
using vercel_ddns_backend.Models.Get;
using vercel_ddns_backend.Models.Patch;
using vercel_ddns_backend.Models.Post;

namespace vercel_ddns_backend.Services;

public class VercelDnsService : IDnsService
{
    private const string VercelUrl = "https://api.vercel.com/v4/domains";
    private readonly string? _apiKey;

    public VercelDnsService(IConfiguration config) => _apiKey = config.GetValue<string>("DnsApiKey");
    
    /// <summary>
    /// Instantiates a new <c>RestClient</c>.
    /// </summary>
    /// <param name="baseUrl">Base Url</param>
    /// <returns>Instantiated RestClient with API token.</returns>
    private RestClient GetClient(string baseUrl) =>
        new RestClient(baseUrl).AddDefaultHeader(KnownHeaders.Authorization, $"Bearer {_apiKey}");
    
    /// <summary>
    /// Gets the 20 latest dns records from Vercel.
    /// </summary>
    /// <param name="domain">The domain name.</param>
    public async Task<VercelGetResponse?> GetRecords(string domain)
    {
        try
        {
            var request = new RestRequest();
            var resp = await this.GetClient($"{VercelUrl}/{domain}/records")
                .GetAsync<VercelGetResponse>(request);

            return resp;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Something went wrong getting the records. \n" + exception.Message);
            return null;
        }
    }

    public async Task<VercelGetByIdResponse?> GetRecord(string recordId)
    {
        try
        {
            var request = new RestRequest();
            var resp = await this.GetClient($"{VercelUrl}/records/{recordId}")
                .GetAsync<VercelGetByIdResponse>(request);

            return resp;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Something went wrong getting the record. \n" + exception.Message);
            return null;
        }
    }

    /// <summary>
    /// Creates a dns record on Vercel.
    /// </summary>
    /// <param name="domain">The domain name.</param>
    /// <param name="record">The record data to be added.</param>
    public async Task<VercelPostResponse?> CreateRecord(string domain, VercelPostRequest record)
    {
        try
        {
            var request = new RestRequest().AddJsonBody(record);
            var resp = await this.GetClient($"{VercelUrl}/{domain}/records")
                .ExecutePostAsync(request);
            
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            
            var result = JsonSerializer.Deserialize<VercelPostResponse>(resp.Content!, serializeOptions);
            
            return result;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Something went wrong creating a record. \n" + exception.Message);
            return null;
        }
    }

    /// <summary>
    /// Updates the record on vercel.
    /// </summary>
    /// <param name="recordId">The uid for the record.</param>
    /// <param name="record">The record data to be updated.</param>
    public async Task<VercelPatchResponse?> UpdateRecord(string recordId, VercelPatchRequest record)
    {
        try
        {
            var request = new RestRequest().AddJsonBody(record);
            var resp = await this.GetClient($"{VercelUrl}/records/{recordId}")
                .PatchAsync<VercelPatchResponse>(request);

            return resp;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Something went wrong updating a record. \n" + exception.Message);
            return null;
        }
    }

    /// <summary>
    /// Removes a record from Vercel.
    /// </summary>
    /// <param name="domain">The domain name.</param>
    /// <param name="recordId">The uid of the record to remove.</param>
    /// <returns>True if successful.</returns>
    public async Task<bool> DeleteRecord(string domain, string recordId)
    {
        try
        {
            var request = new RestRequest();
            var resp = await this.GetClient($"{VercelUrl}/{domain}/records/{recordId}")
                .DeleteAsync(request);

            return resp.StatusCode is HttpStatusCode.OK;
        }
        catch (Exception exception)
        {
            Console.WriteLine("Something went wrong deleting a record. \n" + exception.Message);
            return false;
        }
    }

}