using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class DecorCakeSpecification
    {
        public string ProductName { get; set; } = null!;
        public string DecorCakeArticul { get; set; } = null!;
        public int CountOperationSpecification { get; set; }

        public virtual DecorCake DecorCakeArticulNavigation { get; set; } = null!;
        public virtual Product ProductNameNavigation { get; set; } = null!;
    }
}
