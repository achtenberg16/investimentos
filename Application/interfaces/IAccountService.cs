using Application.Dto;
using infrastructure.Entities;

namespace Application.interfaces;

public interface IAccountService
{
    public Task<AccountBalanceDto?> GetAccountBalance(int clientId);
    public Task<IEnumerable<AccountTransactionDto>?> GetAccountStatement(int clientId);
}