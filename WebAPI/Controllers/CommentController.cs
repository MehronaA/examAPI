using System;
using Domain.Entities;
using Infrastructure.APIResponces;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/comment")]
public class CommentController
{
    private readonly ICommentService commentService = new CommentService();

    [HttpPost]
    public async Task<Responce<string>> CreateComment(Comment comment)
    {
        return await commentService.CreateComment(comment);
    }

    [HttpGet]
    public async Task<Responce<List<Comment>>> GetComments()
    {
        return await commentService.GetComment();
    }

    [HttpPut("{id:int}")]
    public async Task<Responce<string>> UpdateComment(int id, Comment comment)
    {
        comment.Id = id;
        return await commentService.UpdateComment(comment);
    }

    [HttpDelete("{id}")]
    public async Task<Responce<string>> DeleteComment(int id)
    {
        return await commentService.DeleteComment(id);
    }
    
    [HttpGet("{id}")]
    public async Task<Responce<Comment>> GetById(int id)
    {
        return await commentService.GetById(id);
    }
}
