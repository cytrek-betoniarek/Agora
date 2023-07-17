namespace Agora.Contracts.Authentication;

public record RegisterUserRequest(
    string Email,
    string FirstName,
    string LastName,
    string Password,
    string BirthDate
    );
