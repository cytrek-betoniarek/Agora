using Agora.Application.Common.Authentication;
using Agora.Application.Common.Persistence;
using Agora.Domain.Account;
using Agora.Domain.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Authentication.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<LoginResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IAccountRepository _accountRepository;
    private readonly IPasswordManager _passwordManager;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IAccountRepository accountRepository, IPasswordManager passwordManager)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _accountRepository = accountRepository;
        _passwordManager = passwordManager;
    }

    public async Task<ErrorOr<LoginResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Validate the user exists
        if (await _accountRepository.GetAccountByEmailAsync(query.Email) is not Account account)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Validate the password is correct
        if (!_passwordManager.Verify(query.Password, account.PasswordHash))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(account);

        return new LoginResult(token);
    }
}
