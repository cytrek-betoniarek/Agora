using Agora.Application.Authentication.Login;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.AddFavourite;

public class AddFavouriteCommandValidator : AbstractValidator<AddFavouriteCommand>
{
    public AddFavouriteCommandValidator()
    {
        RuleFor(c => c.DiscussionId).NotEmpty();
    }
}
