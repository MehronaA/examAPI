using System;
using Dapper;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ClapService : IClapService
{
    private readonly DataContext _context;
    public ClapService(DataContext context)
    {
        _context = context;
    }

    public async Task<Responce<string>> CreateClap(Clap clap)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "insert into clap(articleId,userId,count,createdAt) values(@articleId,@userId,@count,@createdAt)";
        var result = await connection.ExecuteAsync(cmd, clap);
        return result == 0
                ? Responce<string>.Fail(500, "Something goes wrong")
                : Responce<string>.Created("Created successfuly");
    }
    public async Task<Responce<Clap>> GetById(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from claps where id =@id";
        var result = await connection.QueryFirstOrDefaultAsync<Clap>(cmd, new { id });
        return result == null
                ? Responce<Clap>.Fail(500, "Not updated")
                : Responce<Clap>.Ok(result, null);
            
    }

    public async Task<Responce<string>> DeleteClap(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "delete from claps where id =@id";
        var result = await connection.ExecuteAsync(cmd, new { id });
        return result == 0
                ? Responce<string>.Fail(500, "Not deleted")
                : Responce<string>.Created("Deleted successfuly");
    }

    public async Task<Responce<List<Clap>>> GetClaps()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from claps";
        var result = await connection.QueryAsync<Clap>(cmd);
        return Responce<List<Clap>>.Ok(result.ToList(),null);
    }

    public async Task<Responce<string>> UpdateClap(Clap clap)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "update claps set articleId=@articleId,userId=@userId,count=@count,createdAt=@createdAt where id =@id";
        var result = await connection.ExecuteAsync(cmd, clap);
        return result == 0
                ? Responce<string>.Fail(500, "Not updated")
                : Responce<string>.Created("Updated successfuly");
    }
}
