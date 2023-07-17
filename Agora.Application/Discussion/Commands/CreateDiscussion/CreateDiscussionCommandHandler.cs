using Agora.Application.Common.Persistence;
using Agora.Application.Discussion.Commands.AddFavourite;
using Agora.Domain.Discussion;
using Agora.Domain.Discussion.Entities;
using Agora.Domain.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.CreateDiscussion;

public class CreateDiscussionCommandHandler : IRequestHandler<CreateDiscussionCommand, ErrorOr<CreateDiscussionResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public CreateDiscussionCommandHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<CreateDiscussionResult>> Handle(CreateDiscussionCommand command, CancellationToken cancellationToken)
    {
        Domain.Discussion.Discussion discussion = new Domain.Discussion.Discussion
        (
            Guid.Parse(command.UserId),
            command.Title,
            command.Description,
            DateTime.UtcNow
        );

        await _discussionRepository.AddAsync(discussion);

        return new CreateDiscussionResult();
    }
}
