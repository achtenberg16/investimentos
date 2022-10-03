using Application.Dto;

namespace Application.interfaces;

public interface IAccountService
{
    public Task<AccountBalanceDto?> GetAccountBalance(int accountId);
}