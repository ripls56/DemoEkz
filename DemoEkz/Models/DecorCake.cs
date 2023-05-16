using System;
using System.Collections.Generic;

namespace DemoEkz.Models
{
    public partial class DecorCake
    {
        public DecorCake()
        {
            DecorCakeSpecifications = new HashSet<DecorCakeSpecification>();
        }

        public string ArticulDecorCake { get; set; } = null!;
        public string NameDecorCake { get; set; } = null!;
        public string UnitMeasurementsDecorCake { get; set; } = null!;
        public int CountDecorCake { get; set; }
        public string? ProviderName { get; set; }
        public byte[]? ImageDecorCake { get; set; }
        public string TypeNameDecorCake { get; set; } = null!;
        public decimal BuyCostDecorCake { get; set; }
        public decimal WeightDecorCake { get; set; }

        public virtual Provider? ProviderNameNavigation { get; set; }
        public virtual ICollection<DecorCakeSpecification> DecorCakeSpecifications { get; set; }
    }
}
