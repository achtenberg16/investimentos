using infrastructure.Entities;
using infrastructure.interfaces;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Dao;

public class InvestimentDao : IInvestimentDao
{
    private readonly Context.Context _context;

    public InvestimentDao(Context.Context context)
    {
        _context = context;
    }

    public User GetUserInvestiments(int userId)
    {
        var user = _context.Users
            .Include(u => u.Operations)
            .Include(u => u.AssetsPortfolios)
            .First(u => u.Id == userId);
        return user;
    }

    public void AddTransactionBuyAndUpdateActives(User user, Ticker active, int quantity)
    {
        var activeInAsset = user.AssetsPortfolios.FirstOrDefault(AP => AP.TickerId == active.Id);
        if (activeInAsset is null)
        {
            user.AssetsPortfolios.Add(new AssetsPortfolio() {Quantity = quantity, UserId = user.Id, TickerId = active.Id});
        }

        if (activeInAsset is not null)
        {
            activeInAsset.Quantity += quantity;
        }

        active.Quantity -= quantity;
        user.Operations.Add(new Operation()
            {UnitPrice = active.UnitPrice, Quantity = quantity, UserId = user.Id, TickerId = active.Id, TypeId = 1});
        _context.Accounts.FirstOrDefault(ac => ac.Id == user.Id).Balance -= active.UnitPrice * quantity;

        _context.SaveChanges();
    }
    
    public void AddTransactionSellAndUpdateActives(User user, Ticker active, int quantity)
    {
        var activeInAsset = user.AssetsPortfolios.FirstOrDefault(AP => AP.TickerId == active.Id);
        activeInAsset.Quantity -= quantity;
        if (activeInAsset.Quantity == 0)
        {
            user.AssetsPortfolios.Remove(activeInAsset);
        }
      

        active.Quantity += quantity;
        user.Operations.Add(new Operation()
            {UnitPrice = active.UnitPrice, Quantity = quantity, UserId = user.Id, TickerId = active.Id, TypeId = 2});
        _context.Accounts.FirstOrDefault(ac => ac.Id == user.Id).Balance += active.UnitPrice * quantity;

        _context.SaveChanges();
    }

    public IEnumerable<AssetsPortfolio> GetAssetByUserId(int userId)
    {
        var Asset = _context.AssetsPortfolios.Where(AP => AP.UserId == userId)
            .Include(A => A.Ticker).ToList();
        return Asset;
    }

    public IEnumerable<Operation> GetOperations(int userId)
    {
        var operations = _context.Operations
                .Include(o => o.Ticker)
                    .Where(op => op.UserId == userId).ToList().OrderBy(op => op.Id);
        return operations;
    }
    
}