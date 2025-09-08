using System;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.DTO;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticController
{
    private readonly IStatisticService statisticService = new StatisticService();

    [HttpGet("user-article-{userId:int}")]
    public async Task<Responce<List<Article>>> GetUserArticlesAsync(int userId)
    {
        return await statisticService.GetUserArticlesAsync(userId);
    }

    [HttpGet("recent-article-comments-{articleId:int}")]
    public async Task<Responce<List<Comment>>> GetArticleRecentCommentsAsync(int articleId)
    {
        return await statisticService.GetArticleRecentCommentsAsync(articleId);
    }

    [HttpGet("article-with-claps-count")]

    public async Task<Responce<List<ArticleAndClapCountDTO>>> GetArticleClapsCountAsync()
    {
        return await statisticService.GetArticleClapsCountAsync();
    }

    [HttpGet("article-with-username")]

    public async Task<Responce<List<RecentPublishedArticleDTO>>> GetRecentArticlesAsync()
    {
        return await statisticService.GetRecentArticlesAsync();
    }

    [HttpGet("user-with-comment-and-article-count")]

    public async Task<Responce<List<UsersCommentAndArticleCountDTO>>> GetUserStatsAsync()
    {
        return await statisticService.GetUserStatsAsync();
    }







}
