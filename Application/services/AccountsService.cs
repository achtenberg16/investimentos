using Application.Dto;
using Application.interfaces;
using infrastructure.Context;
using infrastructure.Entities;

namespace Application.services;

public class AccountsService : IAccountService
{
    private readonly Context _context;

    public AccountsService(Context context)
    {
        _context = context;
    }

    public async Task<AccountBalanceDto?> GetAccountBalance(int accountId)
    {
        var account = await _context.Accounts.FindAsync(accountId);
        if (account is null) return null;
        var accountFormatted = new AccountBalanceDto { Balance = account.Balance, Id = account.Id, UserId = account.UserId };
        return accountFormatted;
    }
}