using Agora.Application.Discussion.Commands.AddFavourite;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Queries.DiscussionsList;

public class DiscussionsListQueryValidator : AbstractValidator<DiscussionsListQuery>
{
    public DiscussionsListQueryValidator() { }
}
