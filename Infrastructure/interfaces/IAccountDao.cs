using infrastructure.Entities;

namespace infrastructure.interfaces;

public interface IAccountDao
{
    public Task<Account?> GetAccountBalance(int userId);
    public List<DepositWithdrawal>? GetAccountStatement(int userId);
    public Task<Boolean> AccountExist(int userId);
}