using System;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/clap")]
public class ClapController
{
    private readonly IClapService clapService = new ClapService();

    [HttpPost]
    public async Task<Responce<string>> CreateClap(Clap clap)
    {
        return await clapService.CreateClap(clap);
    }

    [HttpGet]
    public async Task<Responce<List<Clap>>> GetClaps()
    {
        return await clapService.GetClaps();
    }

    [HttpPut]
    public async Task<Responce<string>> UpdateClap(Clap clap)
    {
        return await clapService.UpdateClap(clap);
    }

    [HttpDelete("{id}")]
    public async Task<Responce<string>> DeleteClap(int id)
    {
        return await clapService.DeleteClap(id);
    }
}
