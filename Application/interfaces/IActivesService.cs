using Application.Dto;

namespace Application.interfaces;

public interface IActivesService 
{
    public IEnumerable<TickerResultDto> GetActives();
}