using System;
using Domain.DTO;
using Domain.Entities;
using Infrastructure.APIResponces;

namespace Infrastructure.Interfaces;

public interface IStatisticService
{
    Task<Responce<List<Article>>> GetUserArticlesAsync(int userId);
    Task<Responce<List<Comment>>> GetArticleRecentCommentsAsync(int articleId);
    Task<Responce<List<ArticleAndClapCountDTO>>> GetArticleClapsCountAsync();
    Task<Responce<List<RecentPublishedArticleDTO>>> GetRecentArticlesAsync();
    Task<Responce<List<UsersCommentAndArticleCountDTO>>> GetUserStatsAsync();
}
