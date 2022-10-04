using Application.Dto;

namespace Application.interfaces;

public interface IActivesService 
{
    public IEnumerable<TickerResultDto> GetActives();
    public TickerResultDto GetActivesById(int id);
}