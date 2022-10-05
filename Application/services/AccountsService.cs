using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Application.Dto;
using Application.interfaces;
using infrastructure.Context;
using infrastructure.Entities;
using infrastructure.interfaces;

namespace Application.services;

public class AccountsService : IAccountService
{
    private readonly IAccountDao _accountDao;

    public AccountsService(IAccountDao Dao)
    {
        _accountDao = Dao;
    }

    public AccountBalanceDto? GetAccountBalance(int userId)
    {
        var account = _accountDao.GetAccountBalance(userId);
        if (account is null) return null;
        var accountFormatted = new AccountBalanceDto  (account.Id, account.UserId, account.Balance);
        return accountFormatted;
    }

    public async Task<IEnumerable<AccountTransactionDto>?> GetAccountStatement(int clientId)
    {
        var account = await _accountDao.AccountExist(clientId);
        if (!account) return null;
        var transactions = _accountDao.GetAccountStatement(clientId);
        var transactionsFormated =
            transactions.Select(t => new AccountTransactionDto(t.Id, t.AccountId, t.Value, t.Date, t.TypeId));
        return transactionsFormated;
    }

    public string? Deposit(int accountId, TransactionValueDto transactionInfos)
    {
        if (transactionInfos.valor <= 0) return "O valor de depósito deve ser maior que 0";
        var accountFound = _accountDao.GetAccountBalance(accountId);
        _accountDao.Deposit(accountFound, transactionInfos.valor);
        return null;
    }

    public string? Withdrawal(int accountId, TransactionValueDto transactionInfos)
    {
        if (transactionInfos.valor <= 0) return "O valor de retirada deve ser maior que 0";
        var accountFound = _accountDao.GetAccountBalance(accountId);
        if (accountFound.Balance < transactionInfos.valor)
            return $"valor invalido, seu saldo é de: {accountFound.Balance}";
        _accountDao.Withdrawal(accountFound, transactionInfos.valor);
        return null;
    }
}