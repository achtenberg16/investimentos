using System;
using System.Collections.Generic;

namespace infrastructure.Entities
{
    public partial class DepositWithdrawal
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Value { get; set; }
        public DateTime? Date { get; set; }
        public int? TypeId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual TransactionType? Type { get; set; }
    }
}
