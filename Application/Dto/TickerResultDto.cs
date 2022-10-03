namespace Application.Dto;

public record TickerResultDto
{
    public int Id { get; set; }
    public string Ticker { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}