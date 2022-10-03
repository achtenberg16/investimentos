using infrastructure.Entities;
using infrastructure.interfaces;

namespace infrastructure.Dao;

public class AccountDao : IAccountDao
{
    private readonly Context.Context _context;

    public AccountDao(Context.Context context)
    {
        _context = context;
    }
    
    public async Task<Account?> GetAccountBalance(int userId)
    {
        var account = await _context.Accounts.FindAsync(userId);
        return account;
    }
    
    public List<DepositWithdrawal>? GetAccountStatement(int userId)
    {
        var accountStatement = _context.DepositWithdrawals.Where(dep => dep.AccountId == userId).ToList();
        return accountStatement;
    }

    public async Task<Boolean> AccountExist(int userId)
    {
        var account = await _context.Accounts.FindAsync(userId);
        return account is not null;
    }
}