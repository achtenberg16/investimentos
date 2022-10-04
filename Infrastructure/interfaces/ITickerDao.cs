using infrastructure.Entities;

namespace infrastructure.interfaces;

public interface ITickerDao
{
    public IEnumerable<Ticker> GetActives();
    public Ticker? GetActiveById(int id);

}