using Agora.Application.Authentication.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.DeleteDiscussion;

public class DeleteDiscussionCommandValidator : AbstractValidator<DeleteDiscussionCommand>
{
    public DeleteDiscussionCommandValidator()
    {
        RuleFor(c => c.DiscussionId).NotEmpty();
    }
}
