using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Domain.Errors;

public static partial class Errors
{
    public static class Discussion
    {
        public static Error DatabaseFailure => Error.Failure(
            code: "Discussion.DatabaseFailure",
            description: "Database failed.");

        public static Error ElementNotFound => Error.NotFound(
            code: "Discussion.ElementNotFound",
            description: "Element with specified id doesn't exist.");

        public static Error Unauthorized => Error.Validation(
            code: "Discussion.Unauthorized",
            description: "You are not authorized to modify this resource.");

        public static Error ElementAlreadyExists => Error.Conflict(
            code: "Discussion.ElementAlreadyExists",
            description: "Specified element already exists.");
    }
}
