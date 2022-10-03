using System.Runtime.Intrinsics.Arm;
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

    public async Task<AccountBalanceDto?> GetAccountBalance(int userId)
    {
        var account = await _accountDao.GetAccountBalance(userId);
        if (account is null) return null;
        var accountFormatted = new AccountBalanceDto { Balance = account.Balance, Id = account.Id, UserId = account.UserId };
        return accountFormatted;
    }

    public async Task<IEnumerable<AccountTransactionDto>?> GetAccountStatement(int clientId)
    {
        var account = await _accountDao.AccountExist(clientId);
        if (!account) return null;
        var transactions = _accountDao.GetAccountStatement(clientId);
        var transactionsFormated =
            transactions.Select(t => new AccountTransactionDto
            {
                type = t.TypeId, 
                Date = t.Date,
                Id = t.Id,
                Value = t.Value,
                AccountId = t.AccountId
            });
        return transactionsFormated;
    }
}