using Application.Dto;
using Application.interfaces;
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
        var activesFormatted = actives.Select(ac => new TickerResultDto(ac.Id, ac.Ticker1, ac.Quantity, ac.UnitPrice));
        return activesFormatted;
    }
}