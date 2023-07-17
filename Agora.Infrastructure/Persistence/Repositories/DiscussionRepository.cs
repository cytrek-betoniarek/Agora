using Agora.Application.Common.Persistence;
using Agora.Domain.Discussion;
using Agora.Domain.Discussion.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Agora.Domain.Errors.Errors;
using Discussion = Agora.Domain.Discussion.Discussion;

namespace Agora.Infrastructure.Persistence.Repositories;

public class DiscussionRepository : IDiscussionRepository
{
    private readonly AgoraDBContext _dbContext;

    public DiscussionRepository(AgoraDBContext dBContext)
    {
        _dbContext = dBContext;
    }

    public async Task AddAsync(Discussion discussion)
    {
        await _dbContext.AddAsync(discussion);
        _dbContext.SaveChanges();
    }

    public async Task AddCommentAsync(Comment comment)
    {
        await _dbContext.AddAsync(comment);
        _dbContext.SaveChanges();
    }

    public async Task AddFavouriteAsync(Favourite favourite)
    {
        await _dbContext.AddAsync(favourite);
        _dbContext.SaveChanges();
    }

    public async Task<bool> DeleteAsync(string discussionId)
    {
        var discussion = await _dbContext.Discussions.FirstOrDefaultAsync(d => d.Id == Guid.Parse(discussionId));
        if (discussion != null)
        {
            _dbContext.Discussions.Remove(discussion);
            _dbContext.SaveChanges();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteCommentAsync(string discussionId, string commentId)
    {
        var discussion = _dbContext.Discussions.FirstOrDefault(d => d.Id == Guid.Parse(discussionId));
        if (discussion != null)
        {
            discussion._comments.RemoveAll(f => f.Id == Guid.Parse(commentId));
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteFavouriteAsync(string discussionId, string favouriteId)
    {
        var discussion = _dbContext.Discussions.FirstOrDefault(d => d.Id == Guid.Parse(discussionId));
        if (discussion != null)
        {
            discussion._favourites.RemoveAll(f => f.Id == Guid.Parse(favouriteId));
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Discussion?> GetByIdAsync(string discussionId)
    {
        return await _dbContext.Discussions.FirstOrDefaultAsync(d => d.Id == Guid.Parse(discussionId));
    }

    public async Task<Comment?> GetCommentByIdAsync(string commentId)
    {
        return await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == Guid.Parse(commentId));
    }

    public async Task<bool> GivenFavouriteExistsAsync(string discussionId, string userId)
    {
        var discussion = await _dbContext.Discussions.FirstOrDefaultAsync(d => d.Id == Guid.Parse(discussionId));
        if (discussion is null) return false;
        return discussion._favourites.Exists(f => f.UserId == Guid.Parse(userId));
    }

    public async Task<Discussion[]> ListAsync()
    {
        return await _dbContext.Discussions.AsQueryable().OrderByDescending(d => d.CreationDate).ToArrayAsync();
    }

    public async Task<Discussion[]> MyFavouriteListAsync(string userId)
    {
        return _dbContext.Discussions
            .AsEnumerable()
            .Where(d => d._favourites.Any(f => f.UserId == Guid.Parse(userId)))
            .OrderByDescending(d => d.CreationDate)
            .ToArray();
    }

    public async Task<Discussion[]> MyListAsync(string userId)
    {
        return _dbContext.Discussions
            .AsEnumerable()
            .Where(d => d.AuthorId == Guid.Parse(userId))
            .OrderByDescending(d => d.CreationDate)
            .ToArray();
    }
}
