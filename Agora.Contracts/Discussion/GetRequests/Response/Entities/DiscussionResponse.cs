using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Contracts.Discussion.GetRequests.Response.Entities;

public record DiscussionResponse(
    Guid Id,
    Guid AuthorId,
    string Title,
    string Description,
    string CreationDate,
    CommentResponse[] Comments,
    FavouriteResponse[] Favourites
    );
