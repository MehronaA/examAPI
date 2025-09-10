using System;
using Dapper;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly DataContext _context;
    public CommentService(DataContext context)
    {
        _context = context;
    }

    public async Task<Responce<string>> CreateComment(Comment comment)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "insert into comments(articleId,userID,content,createdAt) values(@articleId,@userID,@content,@createdAt)";
        var result = await connection.ExecuteAsync(cmd, comment);
        return result == 0
                ? Responce<string>.Fail(500, "Something goes wrong")
                : Responce<string>.Created("Created successfuly");
    }
    public async Task<Responce<Comment>> GetById(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from comments where id =@id";
        var result = await connection.QueryFirstOrDefaultAsync<Comment>(cmd, new { id });
        return result == null
                ? Responce<Comment>.Fail(500, "Not updated")
                : Responce<Comment>.Ok(result, null);
            
    }
    public async Task<Responce<string>> DeleteComment(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "delete from comment where id =@id";
        var result = await connection.ExecuteAsync(cmd, new { id });
        return result == 0
                ? Responce<string>.Fail(500, "Not deleted")
                : Responce<string>.Created("Deleted successfuly");
    }

    public async Task<Responce<List<Comment>>> GetComment()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from comments";
        var result = await connection.QueryAsync<Comment>(cmd);
        return Responce<List<Comment>>.Ok(result.ToList(),null);
    }

    public async Task<Responce<string>> UpdateComment(Comment comment)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "update comment set articleId=@articleId,userID=@userID,content=@content,createdAt=@createdAt where id =@id";
        var result = await connection.ExecuteAsync(cmd, comment);
        return result == 0
                ? Responce<string>.Fail(500, "Not updated")
                : Responce<string>.Created("Updated successfuly");
    }
}
