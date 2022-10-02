using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public partial class AssetsPortfolio
    {
        public int UserId { get; set; }
        public int TickerId { get; set; }
        public int Quantity { get; set; }

        public virtual Ticker Ticker { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
