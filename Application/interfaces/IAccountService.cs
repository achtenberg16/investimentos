using Application.Dto;


namespace Application.interfaces;

public interface IAccountService
{
    public AccountBalanceDto? GetAccountBalance(int clientId);
    public Task<IEnumerable<AccountTransactionDto>?> GetAccountStatement(int clientId);
    public string? Deposit(int accountId, TransactionValueDto transactionInfos);
    public string? Withdrawal(int accountId, TransactionValueDto transactionInfos);
}