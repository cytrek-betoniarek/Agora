using Agora.Application.Authentication.Login;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.AddComment;

public record AddCommentCommand(
    string DiscussionId,
    string Comment,
    string UserId) : IRequest<ErrorOr<AddCommentResult>>;
