using System;

namespace Domain.DTO;

public class RecentPublishedArticleDTO
{
    public string UserName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

}
