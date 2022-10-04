using System;

namespace Application.Dto;

public record AccountTransactionDto(int Id, int AccountId, decimal Value, DateTime Date, int type);


