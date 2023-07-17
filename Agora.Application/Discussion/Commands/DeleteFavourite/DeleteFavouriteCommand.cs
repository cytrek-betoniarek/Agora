using Agora.Application.Authentication.Login;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Commands.DeleteFavourite;

public record DeleteFavouriteCommand(
    string DiscussionId,
    string FavouriteId,
    string UserId) : IRequest<ErrorOr<DeleteFavouriteResult>>;
