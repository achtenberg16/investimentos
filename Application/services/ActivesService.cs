using Application.Dto;
using Application.interfaces;
using infrastructure.Context;


namespace Application.services;

public class ActivesService : IActivesService
{
    private readonly Context _context;

    public ActivesService(Context context)
    {
        _context = context;
    }


    public IEnumerable<TickerResultDto> GetActives()
    {
        var actives = _context.Tickers.ToList();
        var activesFormatted = actives.Select(ac => new TickerResultDto 
            { Id = ac.Id, Quantity = ac.Quantity, UnitPrice = ac.UnitPrice, Ticker = ac.Ticker1 });
        return activesFormatted;
    }
}