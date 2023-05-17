using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class OperationSpecification
    {
        public string ProductName { get; set; } = null!;
        public string NameOperationSpecification { get; set; } = null!;
        public int NumberOperationSpecification { get; set; }
        public string? EquipmentName { get; set; }
        public int QuantitySemiProductSpecification { get; set; }

        public virtual Equipment? EquipmentNameNavigation { get; set; }
        public virtual Product ProductNameNavigation { get; set; } = null!;
    }
}
