using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class SemiProductSpecification
    {
        public string ProductName { get; set; } = null!;
        public string SemiProductName { get; set; } = null!;
        public int CountOperationSpecification { get; set; }

        public virtual Product ProductNameNavigation { get; set; } = null!;
        public virtual Product SemiProductNameNavigation { get; set; } = null!;
    }
}
