using Agora.Application.Authentication.Login;
using Agora.Application.Authentication.RegisterUser;
using Agora.Application.Discussion.Commands.CreateDiscussion;
using Agora.Contracts.Authentication;
using Agora.Contracts.Discussion.PostRequests;
using Mapster;

namespace Agora.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterUserRequest, RegisterUserCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();
    }
}
