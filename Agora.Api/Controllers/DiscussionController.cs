using Agora.Application.Authentication.Login;
using Agora.Application.Authentication.RegisterUser;
using Agora.Application.Discussion.Commands.AddComment;
using Agora.Application.Discussion.Commands.AddFavourite;
using Agora.Application.Discussion.Commands.CreateDiscussion;
using Agora.Application.Discussion.Commands.DeleteComment;
using Agora.Application.Discussion.Commands.DeleteDiscussion;
using Agora.Application.Discussion.Commands.DeleteFavourite;
using Agora.Application.Discussion.Queries.Common;
using Agora.Application.Discussion.Queries.DiscussionsList;
using Agora.Application.Discussion.Queries.MyDiscussionsList;
using Agora.Application.Discussion.Queries.MyFavouritesList;
using Agora.Contracts.Authentication;
using Agora.Contracts.Discussion.GetRequests;
using Agora.Contracts.Discussion.GetRequests.Response;
using Agora.Contracts.Discussion.PostRequests;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace Agora.Api.Controllers;

[Route("[controller]")]
public class DiscussionController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public DiscussionController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    private string ExtractId()
    {
        string token = string.Empty;
        if (HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            token = authHeader.ToString().Split(' ')[1];
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
        return userId!;
    }

    [HttpPost]
    [Route("create")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> CreateDiscussion(CreateDiscussionRequest request)
    {
        string userId = ExtractId();
        var command = _mapper.Map<CreateDiscussionCommand>((request, userId));
        ErrorOr<CreateDiscussionResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("delete")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteDiscussion(DeleteDiscussionRequest request)
    {
        var query = _mapper.Map<DeleteDiscussionCommand>(request);
        ErrorOr<DeleteDiscussionResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("comment/add")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> AddComment(AddCommentRequest request)
    {
        string userId = ExtractId();
        var command = _mapper.Map<AddCommentCommand>((request, userId));
        ErrorOr<AddCommentResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("comment/delete")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> DeleteComment(DeleteCommentRequest request)
    {
        string userId = ExtractId();
        var command = _mapper.Map<DeleteCommentCommand>((request, userId));
        ErrorOr<DeleteCommentResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("favourite/add")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> FavouriteAdd(AddFavouriteRequest request)
    {
        string userId = ExtractId();
        var command = _mapper.Map<AddFavouriteCommand>((request, userId));
        ErrorOr<AddFavouriteResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpPost]
    [Route("favourite/delete")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> FavouriteDelete(DeleteFavouriteRequest request)
    {
        string userId = ExtractId();
        var command = _mapper.Map<DeleteFavouriteCommand>((request, userId));
        ErrorOr<DeleteFavouriteResult> result = await _mediator.Send(command);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors));
    }

    [HttpGet]
    [Route("list")]
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> List([FromQuery] DiscussionsListRequest request)
    {
        var query = _mapper.Map<DiscussionsListQuery>(request);
        ErrorOr<DiscussionsListResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<DiscussionsListResponse>(result)),
            errors => Problem(errors));
    }

    [HttpGet]
    [Route("my/list")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> List([FromQuery] MyDiscussionsListRequest request)
    {
        string userId = ExtractId();
        var query = _mapper.Map<MyDiscussionsListQuery>((request, userId));
        ErrorOr<DiscussionsListResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<DiscussionsListResponse>(result)),
            errors => Problem(errors));
    }

    [HttpGet]
    [Route("favourite/my/list")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> List([FromQuery] MyFavouritesListRequest request)
    {
        string userId = ExtractId();
        var query = _mapper.Map<MyFavouritesListQuery>((request, userId));
        ErrorOr<DiscussionsListResult> result = await _mediator.Send(query);
        return result.Match(
            result => Ok(_mapper.Map<DiscussionsListResponse>(result)),
            errors => Problem(errors));
    }
}
