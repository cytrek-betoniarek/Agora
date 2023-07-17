using Agora.Application.Discussion.Queries.DiscussionsList;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Queries.MyFavouritesList;

public class MyFavouritesListQueryValidator : AbstractValidator<MyFavouritesListQuery>
{
    public MyFavouritesListQueryValidator() { }
}
