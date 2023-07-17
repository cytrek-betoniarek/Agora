using Agora.Application.Authentication.Login;
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
using Mapster;

namespace Agora.Api.Common.Mapping;

public class DiscussionMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateDiscussionRequest request, string userId), CreateDiscussionCommand>()
            .Map(dest => dest.Title, src => src.request.title)
            .Map(dest => dest.Description, src => src.request.description)
            .Map(dest => dest.UserId, src => src.userId);

        config.NewConfig<DeleteDiscussionRequest, DeleteDiscussionCommand>()
            .Map(dest => dest.DiscussionId, src => src.discussionId);

        config.NewConfig<(AddCommentRequest request, string userId), AddCommentCommand>()
            .Map(dest => dest.DiscussionId, src => src.request.discussionId)
            .Map(dest => dest.Comment, src => src.request.comment)
            .Map(dest => dest.UserId, src => src.userId);

        config.NewConfig<(DeleteCommentRequest request, string userId), DeleteCommentCommand>()
            .Map(dest => dest.DiscussionId, src => src.request.discussionId)
            .Map(dest => dest.CommentId, src => src.request.commentId)
            .Map(dest => dest.UserId, src => src.userId);

        config.NewConfig<(AddFavouriteRequest request, string userId), AddFavouriteCommand>()
            .Map(dest => dest.DiscussionId, src => src.request.discussionId)
            .Map(dest => dest.UserId, src => src.userId);

        config.NewConfig<(DeleteFavouriteRequest request, string userId), DeleteFavouriteCommand>()
            .Map(dest => dest.DiscussionId, src => src.request.discussionId)
            .Map(dest => dest.FavouriteId, src => src.request.favouriteId)
            .Map(dest => dest.UserId, src => src.userId);

        config.NewConfig<DiscussionsListRequest, DiscussionsListQuery>();

        config.NewConfig<(MyDiscussionsListRequest request, string userId), MyDiscussionsListQuery>()
            .Map(dest => dest.UserId, src => src.userId);

        config.NewConfig<(MyFavouritesListRequest request, string userId), MyFavouritesListQuery>()
            .Map(dest => dest.UserId, src => src.userId);

        config.NewConfig<DiscussionsListResult, DiscussionsListResponse>();
    }
}
