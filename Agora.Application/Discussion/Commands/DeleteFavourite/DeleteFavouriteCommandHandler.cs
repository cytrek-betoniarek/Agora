using Agora.Application.Common.Persistence;
using Agora.Domain.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.DeleteFavourite;

public class DeleteFavouriteCommandHandler : IRequestHandler<DeleteFavouriteCommand, ErrorOr<DeleteFavouriteResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public DeleteFavouriteCommandHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DeleteFavouriteResult>> Handle(DeleteFavouriteCommand command, CancellationToken cancellationToken)
    {
        if (await _discussionRepository.DeleteFavouriteAsync(command.DiscussionId, command.FavouriteId) is false)
        {
            return Errors.Discussion.ElementNotFound;
        }

        return new DeleteFavouriteResult();
    }
}
