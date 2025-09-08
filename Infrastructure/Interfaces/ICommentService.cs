using System;
using Domain.Entities;
using Infrastructure.APIResponces;

namespace Infrastructure.Interfaces;

public interface ICommentService
{
    Task<Responce<List<Comment>>> GetComment();
    Task<Responce<Comment>> GetById(int id);

    Task<Responce<string>> CreateComment(Comment comment);
    Task<Responce<string>> UpdateComment(Comment comment);
    Task<Responce<string>> DeleteComment(int id);
}
