using System;
using System.Collections.Generic;

namespace infrastructure.Entities
{
    public partial class Operation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TickerId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }

        public virtual Ticker Ticker { get; set; } = null!;
        public virtual OperationType Type { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
