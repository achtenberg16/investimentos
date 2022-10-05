using infrastructure.Entities;

namespace infrastructure.interfaces;

public interface IInvestimentDao
{
    public User GetUserInvestiments(int userId);
    public void AddTransactionBuyAndUpdateActives(User user, Ticker active, int quantity);
    public void AddTransactionSellAndUpdateActives(User user, Ticker active, int quantity);
    public IEnumerable<AssetsPortfolio> GetAssetByUserId(int userId);
}