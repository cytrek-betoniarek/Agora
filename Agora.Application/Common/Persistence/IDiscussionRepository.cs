using Agora.Domain.Discussion;
using Agora.Domain.Discussion.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Common.Persistence;

public interface IDiscussionRepository
{
    Task AddAsync(Domain.Discussion.Discussion discussion);
    Task<Domain.Discussion.Discussion?> GetByIdAsync(string discussionId);
    Task<bool> DeleteAsync(string discussionId);
    Task AddCommentAsync(Comment comment);
    Task<Comment?> GetCommentByIdAsync(string commentId);
    Task<bool> DeleteCommentAsync(string discussionId, string commentId);
    Task AddFavouriteAsync(Favourite favourite);
    Task<bool> GivenFavouriteExistsAsync(string discussionId, string userId);
    Task<bool> DeleteFavouriteAsync(string discussionId, string favouriteId);
    Task<Domain.Discussion.Discussion[]> ListAsync();
    Task<Domain.Discussion.Discussion[]> MyListAsync(string userId);
    Task<Domain.Discussion.Discussion[]> MyFavouriteListAsync(string userId);
}
