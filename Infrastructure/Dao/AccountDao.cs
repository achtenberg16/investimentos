using infrastructure.Entities;
using infrastructure.interfaces;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Dao;

public class AccountDao : IAccountDao
{
    private readonly Context.Context _context;

    public AccountDao(Context.Context context)
    {
        _context = context;
    }
    
    public Account? GetAccountBalance(int userId)
    {
        var account = _context.Accounts
            .Include(a => a.DepositWithdrawals)
            .First(a => a.Id == userId);
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

    public void Deposit(Account account, decimal value)
    {
        account.DepositWithdrawals.Add(new DepositWithdrawal(){ AccountId = account.Id, TypeId = 1, Value = value});
        account.Balance += value;
        _context.SaveChanges();
    }
    
    public void Withdrawal(Account account, decimal value)
    {
        account.DepositWithdrawals.Add(new DepositWithdrawal(){ AccountId = account.Id, TypeId = 2, Value = value});
        account.Balance -= value;
        _context.SaveChanges();
    }
    
}