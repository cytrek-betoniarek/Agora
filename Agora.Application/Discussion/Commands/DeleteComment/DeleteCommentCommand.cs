using Agora.Application.Authentication.Login;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.DeleteComment;

public record DeleteCommentCommand(
    string DiscussionId,
    string CommentId,
    string UserId) : IRequest<ErrorOr<DeleteCommentResult>>;