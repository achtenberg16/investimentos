using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            DepositWithdrawals = new HashSet<DepositWithdrawal>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<DepositWithdrawal> DepositWithdrawals { get; set; }
    }
}
