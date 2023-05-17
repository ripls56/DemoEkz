using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class ArticulSpecification
    {
        public string ProductName { get; set; } = null!;
        public string IngridientArticul { get; set; } = null!;
        public int CountOperationSpecification { get; set; }

        public virtual Ingridient IngridientArticulNavigation { get; set; } = null!;
        public virtual Product ProductNameNavigation { get; set; } = null!;
    }
}
