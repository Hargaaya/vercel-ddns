using vercel_ddns_backend.Models.Get;
using vercel_ddns_backend.Models.Patch;
using vercel_ddns_backend.Models.Post;

namespace vercel_ddns_backend.Interfaces.Services;

public interface IDnsService
{ 
    Task<VercelGetResponse?> GetRecords(string domain);
    Task<VercelGetByIdResponse?> GetRecord(string recordId);
    Task<VercelPostResponse?> CreateRecord(string domain, VercelPostRequest record);
    Task<VercelPatchResponse?> UpdateRecord(string recordId, VercelPatchRequest record);
    Task<bool> DeleteRecord(string domain, string recordId);
}