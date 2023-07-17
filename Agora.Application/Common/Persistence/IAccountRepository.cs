using Agora.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Common.Persistence;

public interface IAccountRepository
{
    Task<Account?> GetAccountByEmailAsync(string email);
    Task AddAsync(Account account);

    Task<bool> UpdatePasswordAsync(string Id, string PasswordHash);
}
