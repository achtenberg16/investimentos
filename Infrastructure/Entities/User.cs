using System;
using System.Collections.Generic;

namespace infrastructure.Entities
{
    public partial class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
            AssetsPortfolios = new HashSet<AssetsPortfolio>();
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<AssetsPortfolio> AssetsPortfolios { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
