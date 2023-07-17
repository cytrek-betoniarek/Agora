using Agora.Application.Common.Persistence;
using Agora.Domain.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Infrastructure.Persistence.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AgoraDBContext _dbContext;

    public AccountRepository(AgoraDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task AddAsync(Account account)
    {
        await _dbContext.AddAsync(account);
        _dbContext.SaveChanges();
    }

    public async Task<Account?> GetAccountByEmailAsync(string email)
    {
        return await _dbContext.Set<Account>().Where(a => a.Email == email).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdatePasswordAsync(string Id, string PasswordHash)
    {
        var account = await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Id.ToString() == Id);
        if (account is null)
            return false;

        account.PasswordHash = PasswordHash;

        await _dbContext.SaveChangesAsync();
        return true;
    }
}
