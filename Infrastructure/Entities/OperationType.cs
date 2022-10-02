using System;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public partial class OperationType
    {
        public OperationType()
        {
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
