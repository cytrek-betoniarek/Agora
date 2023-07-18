using Agora.Application.Authentication.RegisterUser;
using Agora.Application.Common.Authentication;
using Agora.Application.Common.Persistence;
using Agora.Application.Discussion.Commands.AddFavourite;
using Agora.Application.Discussion.Commands.DeleteComment;
using Agora.Application.Discussion.Commands.DeleteDiscussion;
using Agora.Domain.Discussion.Entities;
using ErrorOr;
using Moq;

namespace Agora.Application.UnitTests;

public class DiscussionTests
{
    private readonly Mock<IDiscussionRepository> _discussionRepositoryMock;

    public DiscussionTests()
    {
        _discussionRepositoryMock = new Mock<IDiscussionRepository>();
    }

    [Fact]
    public async Task RemovingNonExistingDiscussion_ShouldReturnErrorAsync()
    {
        var command = new DeleteDiscussionCommand(
            Guid.NewGuid().ToString()
            );

        _discussionRepositoryMock.Setup(
            x => x.DeleteAsync(
                It.IsAny<string>()
                )
            ).ReturnsAsync(false);

        var handler = new DeleteDiscussionCommandHandler(
            _discussionRepositoryMock.Object
            );

        ErrorOr<DeleteDiscussionResult> result = await handler.Handle(command, default);

        Assert.True(result.IsError);
    }

    [Fact]
    public async Task RemovingCommentFromNonExistingDiscussion_ShouldReturnErrorAsync()
    {
        var command = new DeleteCommentCommand(
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()
            );

        _discussionRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<string>()
                )
            ).ReturnsAsync((Domain.Discussion.Discussion?)null);

        var handler = new DeleteCommentCommandHandler(
            _discussionRepositoryMock.Object
            );

        ErrorOr<DeleteCommentResult> result = await handler.Handle(command, default);

        Assert.True(result.IsError);
    }

    [Fact]
    public async Task RemovingNonExistingComment_ShouldReturnErrorAsync()
    {
        var command = new DeleteCommentCommand(
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()
            );

        _discussionRepositoryMock.Setup(
            x => x.GetByIdAsync(
                It.IsAny<string>()
                )
            ).ReturnsAsync(new Domain.Discussion.Discussion(Guid.NewGuid(), string.Empty, string.Empty, DateTime.Now));

        _discussionRepositoryMock.Setup(
            x => x.GetCommentByIdAsync(
                It.IsAny<string>()
                )
            ).ReturnsAsync(new Comment(Guid.NewGuid(), Guid.NewGuid(), string.Empty));

        var handler = new DeleteCommentCommandHandler(
            _discussionRepositoryMock.Object
            );

        ErrorOr<DeleteCommentResult> result = await handler.Handle(command, default);

        Assert.True(result.IsError);
    }

    [Fact]
    public async Task AddingExistingFavourite_ShouldReturnErrorAsync()
    {
        var command = new AddFavouriteCommand(
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString()
            );

        _discussionRepositoryMock.Setup(
            x => x.GivenFavouriteExistsAsync(
                It.IsAny<string>(),
                It.IsAny<string>()
                )
            ).ReturnsAsync(true);

        var handler = new AddFavouriteCommandHandler(
            _discussionRepositoryMock.Object
            );

        ErrorOr<AddFavouriteResult> result = await handler.Handle(command, default);

        Assert.True(result.IsError);
    }
}