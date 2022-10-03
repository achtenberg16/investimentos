using System;
using System.Collections.Generic;

namespace infrastructure.Entities
{
    public partial class Account
    {
        public Account()
        {
            DepositWithdrawals = new HashSet<DepositWithdrawal>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<DepositWithdrawal> DepositWithdrawals { get; set; }
    }
}
