using infrastructure.Entities;

namespace infrastructure.interfaces;

public interface IAccountDao
{
    public Account GetAccountBalance(int userId);
    public List<DepositWithdrawal>? GetAccountStatement(int userId);
    public Task<Boolean> AccountExist(int userId);
    public void Deposit(Account account, decimal value);
    public void Withdrawal(Account account, decimal value);
}