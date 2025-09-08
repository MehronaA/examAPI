using System;
using Domain.Entities;
using Infrastructure.APIResponces;

namespace Infrastructure.Interfaces;

public interface IClapService
{
    Task<Responce<List<Clap>>> GetClaps();
    Task<Responce<Clap>> GetById(int id);

    Task<Responce<string>> CreateClap(Clap clap);
    Task<Responce<string>> UpdateClap(Clap clap);
    Task<Responce<string>> DeleteClap(int id);
}
