using Application.Dto;
using Application.interfaces;
using infrastructure.Entities;
using infrastructure.interfaces;

namespace Application.services;

public class InvestimentsService : IInvestimentsService
{
    private readonly IInvestimentDao _investimentDao;
    private readonly ITickerDao _tickerDao;
    private readonly IAccountDao _accountDao;
    public InvestimentsService(IInvestimentDao investimentDao, ITickerDao tickerDao, IAccountDao accountDao)
    {
        _investimentDao = investimentDao;
        _tickerDao = tickerDao;
        _accountDao = accountDao;
    }

    public string? Buy(int accountId, InvestimentTransactionDto infos)
    {
        if (infos.qtdeAtivo < 1) return "não é possivel comprar uma quantidade menor que 1";
        var user = _investimentDao.GetUserInvestiments(accountId);
        var account = _accountDao.GetAccountBalance(accountId);
        var active = _tickerDao.GetActiveById(infos.codAtivo);
        if (active is null) return "o ativo não é valido";
        if (active.Quantity < infos.qtdeAtivo) return "a quantidade não está disponivel";
        if (account.Balance < active.UnitPrice * infos.qtdeAtivo) return "saldo insuficiente";
        _investimentDao.AddTransactionBuyAndUpdateActives(user, active, infos.qtdeAtivo);
        return null;
    }
    
    public string? Sell(int accountId, InvestimentTransactionDto infos)
    {
        if (infos.qtdeAtivo < 1) return "não é possivel vender uma quantidade menor que 1";
        var user = _investimentDao.GetUserInvestiments(accountId);
        var active = _tickerDao.GetActiveById(infos.codAtivo);
        var activeInasset = user.AssetsPortfolios.FirstOrDefault(ap => ap.TickerId == active.Id);
        if (active is null) return "o ativo não é valido";
        if (activeInasset is null) return "não é possivel vender um ativo que não esteja em sua carteira";
        if (activeInasset.Quantity < infos.qtdeAtivo) return "Você não possui a quantidade disponível em sua carteira";
        _investimentDao.AddTransactionSellAndUpdateActives(user, active, infos.qtdeAtivo);
        return null;
    }

    public IEnumerable<AssetInvestimentsDto> GetAsset(int userId)
    {
        var asset = _investimentDao.GetAssetByUserId(userId);
        var assetFormatted = asset.Select(transaction =>
        {
            var active = transaction.Ticker;
            return new AssetInvestimentsDto(transaction.TickerId, transaction.UserId, active.UnitPrice, active.Ticker1,
                transaction.Quantity);
        });
        return assetFormatted;
    }
    
    public IEnumerable<ExtractInvestimentsDto> GetOperations(int userId)
    {
        var operations = _investimentDao.GetOperations(userId);
        var operationsFormated = operations.Select(op =>
        {
            var oprationType = op.TypeId == 1 ? "compra" : "venda";
            var ticker = op.Ticker;
            return new ExtractInvestimentsDto(op.Id, op.TickerId, op.UserId, op.Quantity, op.UnitPrice, ticker.Ticker1,
                oprationType, op.Date);
        });
        return operationsFormated;
    }
}