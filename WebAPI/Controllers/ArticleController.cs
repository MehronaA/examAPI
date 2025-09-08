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
        return await articleService.GetArticle();
    }

    [HttpPut]
    public async Task<Responce<string>> UpdateArticle(Article article)
    {
        return await articleService.UpdateArticle(article);
    }

    [HttpDelete("{id}")]
    public async Task<Responce<string>> DeleteArticle(int id)
    {
        return await articleService.DeleteArticle(id);
    }
    
    
}
