using System;
using System.Collections.Generic;

namespace PP.Domain.DatabaseFirstPatter
{
    public partial class EmployeeOrder
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int OrderId { get; set; }
    }
}
