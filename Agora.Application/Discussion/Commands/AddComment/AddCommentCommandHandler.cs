using Agora.Application.Authentication.Login;
using Agora.Application.Common.Authentication;
using Agora.Application.Common.Persistence;
using Agora.Domain.Discussion.Entities;
using Agora.Domain.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.AddComment;

public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, ErrorOr<AddCommentResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public AddCommentCommandHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<AddCommentResult>> Handle(AddCommentCommand command, CancellationToken cancellationToken)
    {
        if (await _discussionRepository.GetByIdAsync(command.DiscussionId) is null)
        {
            return Errors.Discussion.ElementNotFound;
        }

        Comment comment = new Comment
        (
            Guid.Parse(command.UserId),
            Guid.Parse(command.DiscussionId),
            command.Comment
        );

        await _discussionRepository.AddCommentAsync(comment);

        return new AddCommentResult();
    }
}
