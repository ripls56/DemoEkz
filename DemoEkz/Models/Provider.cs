using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class Provider
    {
        public Provider()
        {
            DecorCakes = new HashSet<DecorCake>();
            Ingridients = new HashSet<Ingridient>();
        }

        public string NameProvider { get; set; } = null!;
        public string? AddresProvider { get; set; }
        public int DeliveryPeriodProvider { get; set; }

        public virtual ICollection<DecorCake> DecorCakes { get; set; }
        public virtual ICollection<Ingridient> Ingridients { get; set; }
    }
}
