using System;
using System.ComponentModel;
using Domain.Entities;
using Infrastructure.APIResponces;

namespace Infrastructure.Interfaces;

public interface IArticleService
{
    Task<Responce<List<Article>>> GetArticle();
    Task<Responce<string>> CreateArticle(Article article);
    Task<Responce<string>> UpdateArticle(Article article);
    Task<Responce<string>> DeleteArticle(int id);

}
