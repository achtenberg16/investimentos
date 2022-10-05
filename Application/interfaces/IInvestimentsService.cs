using Application.Dto;

namespace Application.interfaces;

public interface IInvestimentsService
{
    public string? Buy(int accountId, InvestimentTransactionDto infos);
    public string? Sell(int accountId, InvestimentTransactionDto infos);
    public IEnumerable<AssetInvestimentsDto> GetAsset(int userId);
    public IEnumerable<ExtractInvestimentsDto> GetOperations(int userId);
}