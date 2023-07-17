using Agora.Application.Common.Authentication;
using Agora.Application.Common.Persistence;
using Agora.Domain.Account;
using Agora.Domain.Accounts;
using Agora.Domain.Errors;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Authentication.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<RegisterUserResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordManager _passwordManager;
    private readonly IAccountRepository _accountRepository;

    public RegisterUserCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IAccountRepository accountRepository, IPasswordManager passwordManager)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _accountRepository = accountRepository;
        _passwordManager = passwordManager;
    }

    public async Task<ErrorOr<RegisterUserResult>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        if (await _accountRepository.GetAccountByEmailAsync(command.Email) is not null)
        {
            return Errors.Account.DuplicateEmail;
        }

        var account = new Account
        (
            command.Email,
            command.FirstName,
            command.LastName,
            command.BirthDate,
            _passwordManager.Hash(command.Password),
            AccountRoles.User
        );

        await _accountRepository.AddAsync(account);

        return new RegisterUserResult();
    }
}
