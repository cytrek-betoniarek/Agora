using Agora.Application.Authentication.Login;
using Agora.Application.Authentication.RegisterUser;
using Agora.Application.Common.Authentication;
using Agora.Application.Common.Persistence;
using Agora.Domain.Account;
using ErrorOr;
using Moq;

namespace Agora.Application.UnitTests;

public class AccountTests
{
    private readonly Mock<IAccountRepository> _accountRepositoryMock;
    private readonly Mock<IPasswordManager> _passwordManagerMock;
    private readonly Mock<IJwtTokenGenerator> _jwtTokenGeneratorMock;

    public AccountTests()
    {
        _accountRepositoryMock = new Mock<IAccountRepository>();
        _passwordManagerMock = new Mock<IPasswordManager>();
        _jwtTokenGeneratorMock = new Mock<IJwtTokenGenerator>();
    }

    [Fact]
    public async Task CreatingAccountWithUsedEmail_ShouldReturnErrorAsync()
    {
        var command = new RegisterUserCommand(
            "test@mail.com",
            "Name",
            "LastName",
            "Password1!",
            DateTime.Now
            );

        _accountRepositoryMock.Setup(
            x => x.GetAccountByEmailAsync(
                It.IsAny<string>()
                )
            ).ReturnsAsync(new Account(string.Empty, string.Empty, string.Empty));

        var handler = new RegisterUserCommandHandler(
            _jwtTokenGeneratorMock.Object,
            _accountRepositoryMock.Object,
            _passwordManagerMock.Object
            );

        ErrorOr<RegisterUserResult> result = await handler.Handle(command, default);

        Assert.True(result.IsError);
    }

    [Fact]
    public async Task CreatingAccountWithUsedEmail_ShouldBeSuccessfulAsync()
    {
        var command = new RegisterUserCommand(
            "test@mail.com",
            "Name",
            "LastName",
            "Password1!",
            DateTime.Now
            );

        _accountRepositoryMock.Setup(
            x => x.GetAccountByEmailAsync(
                It.IsAny<string>()
                )
            ).ReturnsAsync((Account?)null);

        var handler = new RegisterUserCommandHandler(
            _jwtTokenGeneratorMock.Object,
            _accountRepositoryMock.Object,
            _passwordManagerMock.Object
            );

        ErrorOr<RegisterUserResult> result = await handler.Handle(command, default);

        Assert.False(result.IsError);
    }

    [Fact]
    public async Task LoggingWithInvalidCredentials_ShouldReturnErrorAsync()
    {
        var command = new LoginQuery(
            "test@mail.com",
            "Password1!"
            );

        _accountRepositoryMock.Setup(
            x => x.GetAccountByEmailAsync(
                It.IsAny<string>()
                )
            ).ReturnsAsync((Account?)null);

        var handler = new LoginQueryHandler(
            _jwtTokenGeneratorMock.Object,
            _accountRepositoryMock.Object,
            _passwordManagerMock.Object
            );

        ErrorOr<LoginResult> result = await handler.Handle(command, default);

        Assert.True(result.IsError);
    }

    [Fact]
    public async Task LoggingWithValidCredentials_ShouldBeSuccessfulAsync()
    {
        var command = new LoginQuery(
            "test@mail.com",
            "Password1!"
            );

        _accountRepositoryMock.Setup(
            x => x.GetAccountByEmailAsync(
                It.IsAny<string>()
                )
            ).ReturnsAsync(new Account(string.Empty, string.Empty, string.Empty));

        var handler = new LoginQueryHandler(
            _jwtTokenGeneratorMock.Object,
            _accountRepositoryMock.Object,
            _passwordManagerMock.Object
            );

        ErrorOr<LoginResult> result = await handler.Handle(command, default);

        Assert.False(result.IsError);
    }
}