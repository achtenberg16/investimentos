namespace Application.Dto;

public record AccountTransactionDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public int type { get; set; }
}

