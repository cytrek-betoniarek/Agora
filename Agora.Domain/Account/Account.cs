using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Domain.Account;

public class Account
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string? Email { get; set; } = null!;
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
    public string PasswordHash { get; set; } = null!;
    public string Role { get; init; } = null!;
    private Account() { }
    public Account(string Email, string FirstName, string LastName, DateTime BirthDate, string PasswordHash, string Role)
    {
        this.Email = Email;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.BirthDate = BirthDate;
        this.PasswordHash = PasswordHash;
        this.Role = Role;
    }
    public Account(string Email, string PasswordHash, string Role)
    {
        this.Email = Email;
        this.FirstName = null;
        this.LastName = null;
        this.BirthDate = null;
        this.PasswordHash = PasswordHash;
        this.Role = Role;
    }
}
