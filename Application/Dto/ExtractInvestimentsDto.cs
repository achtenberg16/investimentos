namespace Application.Dto;

public record ExtractInvestimentsDto(int idOperacao, int codAtivo, int codCliente, int qtdeAtivos, decimal valor, string ticker, string tipoOperacao, DateTime dataOperacao );
