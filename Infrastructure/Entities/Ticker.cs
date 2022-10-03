using System;
using System.Collections.Generic;

namespace infrastructure.Entities
{
    public partial class Ticker
    {
        public Ticker()
        {
            AssetsPortfolios = new HashSet<AssetsPortfolio>();
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Ticker1 { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual ICollection<AssetsPortfolio> AssetsPortfolios { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
