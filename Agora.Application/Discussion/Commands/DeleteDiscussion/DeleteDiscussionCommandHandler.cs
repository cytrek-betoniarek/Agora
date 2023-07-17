using Agora.Application.Common.Persistence;
using Agora.Domain.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.DeleteDiscussion;

public class DeleteDiscussionCommandHandler : IRequestHandler<DeleteDiscussionCommand, ErrorOr<DeleteDiscussionResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public DeleteDiscussionCommandHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DeleteDiscussionResult>> Handle(DeleteDiscussionCommand command, CancellationToken cancellationToken)
    {
        if (await _discussionRepository.DeleteAsync(command.DiscussionId) is false)
        {
            return Errors.Discussion.ElementNotFound;
        }

        return new DeleteDiscussionResult();
    }
}
