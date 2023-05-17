using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class UserOrder
    {
        public int NumberUserOrder { get; set; }
        public DateTime DateUserOrder { get; set; }
        public string NameUserOrder { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string SystemUserLogin { get; set; } = null!;
        public string SystemUserPassword { get; set; } = null!;
        public string EmployeeSystemUserLogin { get; set; } = null!;
        public string EmployeeSystemUserPassword { get; set; } = null!;
        public decimal? CostUserOrder { get; set; }
        public DateTime? DateFinishUserOrder { get; set; }
        public byte[]? ExampleUserOrder { get; set; }

        public virtual SystemUser EmployeeSystemUser { get; set; } = null!;
        public virtual Product ProductNameNavigation { get; set; } = null!;
        public virtual SystemUser SystemUser { get; set; } = null!;
    }
}
