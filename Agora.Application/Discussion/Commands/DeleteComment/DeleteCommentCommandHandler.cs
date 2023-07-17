using Agora.Application.Common.Persistence;
using Agora.Application.Discussion.Commands.DeleteComment;
using Agora.Domain.Discussion.Entities;
using Agora.Domain.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.DeleteComment;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, ErrorOr<DeleteCommentResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public DeleteCommentCommandHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DeleteCommentResult>> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
    {
        if (await _discussionRepository.DeleteCommentAsync(command.DiscussionId, command.CommentId) is false)
        {
            return Errors.Discussion.ElementNotFound;
        }

        return new DeleteCommentResult();
    }
}
