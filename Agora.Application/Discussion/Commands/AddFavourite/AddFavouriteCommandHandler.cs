using Agora.Application.Common.Persistence;
using Agora.Application.Discussion.Commands.AddComment;
using Agora.Domain.Discussion.Entities;
using Agora.Domain.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.AddFavourite;

public class AddFavouriteCommandHandler : IRequestHandler<AddFavouriteCommand, ErrorOr<AddFavouriteResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public AddFavouriteCommandHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<AddFavouriteResult>> Handle(AddFavouriteCommand command, CancellationToken cancellationToken)
    {
        if (await _discussionRepository.GetByIdAsync(command.DiscussionId) is null)
        {
            return Errors.Discussion.ElementNotFound;
        }

        if (await _discussionRepository.GivenFavouriteExistsAsync(command.DiscussionId, command.UserId) is true)
        {
            return Errors.Discussion.ElementAlreadyExists;
        }

        Favourite favourite = new Favourite
        (
            Guid.Parse(command.UserId),
            Guid.Parse(command.DiscussionId)
        );

        await _discussionRepository.AddFavouriteAsync(favourite);

        return new AddFavouriteResult();
    }
}
