using System;
using Dapper;
using Domain.DTO;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StatisticService : IStatisticService
{
    private readonly DataContext _context ;
     public StatisticService(DataContext context)
    {
        _context = context;
    }

    public async Task<Responce<List<ArticleAndClapCountDTO>>> GetArticleClapsCountAsync()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select articleId, count(*) from claps group by articleId";
        var result = await connection.QueryAsync<ArticleAndClapCountDTO>(cmd);
        return Responce<List<ArticleAndClapCountDTO>>.Ok(result.ToList(), null);
    }

    public async Task<Responce<List<Comment>>> GetArticleRecentCommentsAsync(int articleId)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from comments where articleId = @articleId order by articleId desc limit 5";
        var result = await connection.QueryAsync<Comment>(cmd, new { articleId});
        return Responce<List<Comment>>.Ok(result.ToList(),null);
    }

    public async Task<Responce<List<RecentPublishedArticleDTO>>> GetRecentArticlesAsync()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = @"select u.userName, a.title,a.content,a.description,a.createdAt 
                    from users u
                    join articles as a on u.id=a.userId
                    where a.status= 'published' order by createdAt desclimit 10";
        var result = await connection.QueryAsync<RecentPublishedArticleDTO>(cmd);
        return Responce<List<RecentPublishedArticleDTO>>.Ok(result.ToList(),null);
    }

    public async Task<Responce<List<Article>>> GetUserArticlesAsync(int userId)
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = "select * from articles where userId=@userId";
        var result = await connection.QueryAsync<Article>(cmd,new { userId});
        return Responce<List<Article>>.Ok(result.ToList(),null);
    }

    public async Task<Responce<List<UsersCommentAndArticleCountDTO>>> GetUserStatsAsync()
    {
        await using var connection = _context.GetConnection();
        connection.Open();
        var cmd = @"select u.id,u.username,Count(c.id) as commentCount,Count(a.id) as articleCount
                    from users as u
                    left join comments as c on c.userId=u.id
                    left join articles as a on a.userId=u.id
                    group by u.id,u.username";
        var result = await connection.QueryAsync<UsersCommentAndArticleCountDTO>(cmd);
        return Responce<List<UsersCommentAndArticleCountDTO>>.Ok(result.ToList(),null);
    }
}
