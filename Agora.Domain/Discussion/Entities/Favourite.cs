using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Domain.Discussion.Entities;

public class Favourite
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public Guid DiscussionId { get; set; }
    public DateTime CreationDate { get; set; }
    private Favourite() { }
    public Favourite(Guid UserId, Guid DiscussionId)
    {
        this.UserId = UserId;
        this.DiscussionId = DiscussionId;
        this.CreationDate = DateTime.UtcNow;
    }
}
