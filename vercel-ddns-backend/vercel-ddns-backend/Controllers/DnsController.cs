using Microsoft.AspNetCore.Mvc;
using vercel_ddns_backend.Interfaces.Services;
using vercel_ddns_backend.Models;

namespace vercel_ddns_backend.Controllers;

public class DnsController : Controller
{
    private readonly IDnsService _dnsService;

    public DnsController(IDnsService dnsService)
    {
        _dnsService = dnsService;
    }
    
    [HttpGet]
    [Route("record")]
    public async Task<IActionResult> GetRecords(string domain)
    {
        var records = await _dnsService.GetRecords(domain);

        return records is null ? NotFound() : Ok(records);
    }

    [HttpPatch]
    [Route("record")]
    public async Task<IActionResult> UpdateRecord(string domain, DnsRecord record)
    {
        var updatedRecord = await _dnsService.UpdateRecord(domain, record);

        return updatedRecord is null ? NotFound() : Ok();
    }

    [HttpDelete]
    [Route("record")]
    public async Task<IActionResult> DeleteRecord(string domain, string recordName)
    {
        var success = await _dnsService.DeleteRecord(domain, recordName);

        return success is false ? NotFound() : Ok();
    }
}