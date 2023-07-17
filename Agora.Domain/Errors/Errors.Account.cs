using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Domain.Errors;

public static partial class Errors
{
    public static class Account
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "Account.DuplicateEmail",
            description: "Email is already in use.");
        public static Error InvalidGuid => Error.Validation(
            code: "Account.InvalidGuid",
            description: "Guid is not valid.");
        public static Error DeletedAccount => Error.Failure(
            code: "Account.Deleted",
            description: "Account with such credentials no longer exists."
            );
    }
}
