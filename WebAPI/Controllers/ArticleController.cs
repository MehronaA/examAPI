using System;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/article")]
public class ArticleController
{
    private readonly IArticleService articleService = new ArticleService();

    [HttpPost]
    public async Task<Responce<string>> CreateArticle(Article article)
    {
        return await articleService.CreateArticle(article);
    }

    [HttpGet]
    public async Task<Responce<List<Article>>> GetArticle()
    {
        return await articleService.GetArticles();
    }

    [HttpPut("{id:int}")]
    public async Task<Responce<string>> UpdateArticle(int id,Article article)
    {
        article.Id = id;
        return await articleService.UpdateArticle(article);
    }

    [HttpDelete("{id:int}")]
    public async Task<Responce<string>> DeleteArticle(int id)
    {
        return await articleService.DeleteArticle(id);
    }
    
    
}
