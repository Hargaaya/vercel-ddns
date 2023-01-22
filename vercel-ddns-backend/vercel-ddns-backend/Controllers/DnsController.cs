using Microsoft.AspNetCore.Mvc;
using vercel_ddns_backend.Interfaces.Services;
using vercel_ddns_backend.Models.Patch;
using vercel_ddns_backend.Models.Post;

namespace vercel_ddns_backend.Controllers;


[Route("record")]
public class DnsController : Controller
{
    private readonly IDnsService _dnsService;

    public DnsController(IDnsService dnsService)
    {
        _dnsService = dnsService;
    }
    
    [HttpGet("/records")]
    public async Task<IActionResult> GetRecords(string domain)
    {
        var records = await _dnsService.GetRecords(domain);

        return records?.Error is not null ? NotFound(records.Error) : Ok(records);
    }

    [HttpGet]
    public async Task<IActionResult> GetRecord(string recordId)
    {
        var record = await _dnsService.GetRecord(recordId);

        return record?.Error is not null ? BadRequest(record.Error) : Ok(record);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecord(string domain, VercelPostRequest record)
    {
        var newRecord = await _dnsService.CreateRecord(domain, record);

        return newRecord?.Error is not null ? BadRequest(newRecord.Error) : CreatedAtAction(nameof(this.GetRecord), new { uid = newRecord?.Uid });
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateRecord(string recordId, VercelPatchRequest record)
    {
        var updatedRecord = await _dnsService.UpdateRecord(recordId, record);

        return updatedRecord?.Error is not null ? BadRequest(updatedRecord.Error) : Ok(updatedRecord);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRecord(string domain, string recordName)
    {
        var success = await _dnsService.DeleteRecord(domain, recordName);

        return success is false ? BadRequest() : NoContent();
    }
}