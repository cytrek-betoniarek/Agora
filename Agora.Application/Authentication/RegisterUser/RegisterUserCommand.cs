using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Authentication.RegisterUser;

public record RegisterUserCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    DateTime BirthDate) : IRequest<ErrorOr<RegisterUserResult>>;
