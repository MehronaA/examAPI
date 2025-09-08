using System;

namespace Domain.DTO;

public class UsersCommentAndArticleCountDTO
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public int CommentCount { get; set; }
    public int ArticleCount { get; set; }
    
}
