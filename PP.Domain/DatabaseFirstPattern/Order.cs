using System;
using System.Collections.Generic;

namespace PP.Domain.DatabaseFirstPatter
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ServiceType { get; set; }
        public bool IsUrgent { get; set; }
        public int Status { get; set; }
        public int PassportId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
