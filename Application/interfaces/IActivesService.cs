using System.Collections.Generic;
using Application.Dto;

namespace Application.interfaces;

public interface IActivesService 
{
    public IEnumerable<TickerResultDto> GetActives();
}