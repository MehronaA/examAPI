using System;
using Dapper;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class ArticleService:IArticleService
{
    private readonly DataContext _context;
    public ArticleService(DataContext context)
    {
        _context = context;
    }

    public async Task<Responce<string>> CreateArticle(Article article)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "insert into articles(userId,title,content,description,createdAt,status) values(@userId,@title,@content,@description,@createdAt,@status)";
        var result = await connection.ExecuteAsync(cmd, article);
        return result == 0
                ? Responce<string>.Fail(500, "Something goes wrong")
                : Responce<string>.Created("Created successfuly");
    }

    public async Task<Responce<string>> DeleteArticle(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "delete from articles where id =@id";
        var result = await connection.ExecuteAsync(cmd, new { id });
        return result == 0
                ? Responce<string>.Fail(500, "Not deleted")
                : Responce<string>.Created("Deleted successfuly");
    }

    public async Task<Responce<List<Article>>> GetArticles()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from articles";
        var result = await connection.QueryAsync<Article>(cmd);
        return Responce<List<Article>>.Ok(result.ToList(),null);
    }

    public async Task<Responce<Article>> GetById(int id)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from articles where id =@id";
        var result = await connection.QueryFirstOrDefaultAsync<Article>(cmd, new { id });
        return result == null
                ? Responce<Article>.Fail(500, "Not updated")
                : Responce<Article>.Ok(result, null);
            
    }

    public async Task<Responce<string>> UpdateArticle(Article article)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "update articles set userId=@userId,title=@title,content=@content,description=@description,createdAt=@createdAt,status=@status where id =@id";
        var result = await connection.ExecuteAsync(cmd, article);
        return result == 0
                ? Responce<string>.Fail(500, "Not updated")
                : Responce<string>.Created("Updated successfuly");
    }
}
