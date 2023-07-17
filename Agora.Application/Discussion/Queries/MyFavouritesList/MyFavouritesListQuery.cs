using Agora.Application.Authentication.Login;
using Agora.Application.Discussion.Queries.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Queries.MyFavouritesList;

public record MyFavouritesListQuery(string UserId) : IRequest<ErrorOr<DiscussionsListResult>>;
