using System;
using Dapper;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly DataContext _context = new();

    public async Task<Responce<string>> CreateUser(User user)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "insert into users(userName,email,passwordHash,bio,createdAt) values(@userName,@email,@passwordHash,@bio,@createdAt)";
        var result = await connection.ExecuteAsync(cmd, user);
        return result == 0
                ? Responce<string>.Fail(500, "Something goes wrong")
                : Responce<string>.Created("Created successfuly");
    }
    public async Task<Responce<User>> GetById(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from users where id =@id";
        var result = await connection.QueryFirstOrDefaultAsync<User>(cmd, new { id });
        return result == null
                ? Responce<User>.Fail(500, "Not updated")
                : Responce<User>.Ok(result, null);
            
    }

    public async Task<Responce<string>> DeleteUser(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "delete from comment where id =@id";
        var result = await connection.ExecuteAsync(cmd, new { id });
        return result == 0
                ? Responce<string>.Fail(500, "Not deleted")
                : Responce<string>.Created("Deleted successfuly");
    }

    public async Task<Responce<List<User>>> GetUsers()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from users";
        var result = await connection.QueryAsync<User>(cmd);
        return Responce<List<User>>.Ok(result.ToList(),null);
    }

    public async Task<Responce<string>> UpdateUser(User user)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "update users set userName=@userName,email=@email,passwordHash=@passwordHash,bio=@bio,createdAt=@createdAt where id =@id";
        var result = await connection.ExecuteAsync(cmd, user);
        return result == 0
                ? Responce<string>.Fail(500, "Not updated")
                : Responce<string>.Created("Updated successfuly");
    }
}
