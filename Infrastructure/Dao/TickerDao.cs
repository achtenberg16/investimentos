using infrastructure.Entities;
using infrastructure.interfaces;

namespace infrastructure.Dao;

public class TickerDao : ITickerDao
{
    private readonly Context.Context _context;

    public TickerDao(Context.Context context)
    {
        _context = context;
    }

    public IEnumerable<Ticker> GetActives()
    {
        var actives =_context.Tickers.ToList();
        return actives;
    }
    
    public Ticker? GetActiveById(int id)
    {
        var actives = _context.Tickers.FirstOrDefault(t => t.Id == id);
        return actives;
    }
    
}