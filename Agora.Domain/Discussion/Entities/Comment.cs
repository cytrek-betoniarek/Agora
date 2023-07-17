using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Domain.Discussion.Entities;

public class Comment
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid AuthorId { get; init; }
    public Guid DiscussionId { get; set; }
    public string Commentary { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    private Comment() { }
    public Comment(Guid AuthorId, Guid DiscussionId, string Commentary)
    {
        this.AuthorId = AuthorId;
        this.DiscussionId = DiscussionId;
        this.Commentary = Commentary;
        this.CreationDate = DateTime.UtcNow;
    }
}
