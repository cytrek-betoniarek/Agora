using Agora.Application.Authentication.Login;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.CreateDiscussion;

public record CreateDiscussionCommand(
    string Title,
    string Description,
    string UserId) : IRequest<ErrorOr<CreateDiscussionResult>>;
