using Agora.Domain.Discussion.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Domain.Discussion;

public class Discussion
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid AuthorId { get; init; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreationDate { get; set; }

    public List<Comment> _comments = new();
    public IReadOnlyList<Comment> Comments => _comments.ToList();

    public List<Favourite> _favourites = new();
    public IReadOnlyList<Favourite> Favourites => _favourites.ToList();
    private Discussion() { }
    public Discussion(Guid AuthorId, string Title, string Description, DateTime CreationDate)
    {
        this.AuthorId = AuthorId;
        this.Title = Title;
        this.Description = Description;
        this.CreationDate = CreationDate;
    }
}
