namespace Application.Dto;

public record AccountBalanceDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
}