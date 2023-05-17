using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class Ingridient
    {
        public Ingridient()
        {
            ArticulSpecifications = new HashSet<ArticulSpecification>();
        }

        public string ArticulIngridient { get; set; } = null!;
        public string NameIngridient { get; set; } = null!;
        public string UnitMeasurementsIngridient { get; set; } = null!;
        public int CountIngridient { get; set; }
        public DateTime ShelfLife { get; set; }
        public string? ProviderName { get; set; }
        public byte[]? ImageIngridient { get; set; }
        public string TypeNameIngridient { get; set; } = null!;
        public decimal BuyCostIngridient { get; set; }
        public string GostIngridient { get; set; } = null!;
        public string PackingIngridient { get; set; } = null!;
        public string DescriptionIngridient { get; set; } = null!;

        public virtual Provider? ProviderNameNavigation { get; set; }
        public virtual ICollection<ArticulSpecification> ArticulSpecifications { get; set; }
    }
}
