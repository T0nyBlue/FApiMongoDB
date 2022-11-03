using AutoMapper;
using FApi.Dtos;
using FApi.Models;
using FApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FController : ControllerBase
{
    private readonly FService _fService;
    private readonly IMapper _mapper;

    public FController(FService booksService, IMapper mapper) {
        _fService = booksService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<List<FModel>> Get() =>
        await _fService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<FModel>> Get(string id)
    {
        var f = await _fService.GetAsync(id);

        if (f is null)
        {
            return NotFound();
        }

        return f;
    }

    [HttpPost]
    public async Task<IActionResult> Post(FModelDto newF)
    {
        FModel f = _mapper.Map<FModel>(newF);
        await _fService.CreateAsync(f);

        return CreatedAtAction(nameof(Get), new { id = f.FId }, f);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, FModel updatedF)
    {
        var f = await _fService.GetAsync(id);

        if (f is null)
        {
            return NotFound();
        }

        updatedF.FId = f.FId;

        await _fService.UpdateAsync(id, updatedF);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var f = await _fService.GetAsync(id);

        if (f is null)
        {
            return NotFound();
        }

        await _fService.RemoveAsync(id);

        return NoContent();
    }
}