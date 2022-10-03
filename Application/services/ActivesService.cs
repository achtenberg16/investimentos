using Application.Dto;
using Application.interfaces;
using infrastructure.Context;
using infrastructure.interfaces;


namespace Application.services;

public class ActivesService : IActivesService
{
    private readonly ITickerDao _tickerDao;

    public ActivesService(ITickerDao tickerDao)
    {
        _tickerDao = tickerDao;
    }


    public IEnumerable<TickerResultDto> GetActives()
    {
        var actives = _tickerDao.GetActives();
        var activesFormatted = actives.Select(ac => new TickerResultDto 
            { Id = ac.Id, Quantity = ac.Quantity, UnitPrice = ac.UnitPrice, Ticker = ac.Ticker1 });
        return activesFormatted;
    }
}