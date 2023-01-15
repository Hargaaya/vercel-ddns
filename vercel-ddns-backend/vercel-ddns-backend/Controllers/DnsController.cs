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
    public async Task<IActionResult> GetRecords(string domainName)
    {
        var records = await _dnsService.GetRecords(domainName);

        return records is null ? NotFound() : Ok(records);
    }

    [HttpPatch]
    [Route("record")]
    public async Task<IActionResult> UpdateRecord(string domainName, DnsRecord recordData)
    {
        var record = await _dnsService.UpdateRecord(domainName, recordData);

        return record is null ? NotFound() : Ok();
    }

    [HttpDelete]
    [Route("record")]
    public async Task<IActionResult> DeleteRecord(string domainName, string recordName)
    {
        var success = await _dnsService.DeleteRecord(domainName, recordName);

        return success is false ? NotFound() : Ok();
    }
}