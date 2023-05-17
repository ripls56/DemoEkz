using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class TypeEquipment
    {
        public TypeEquipment()
        {
            Equipment = new HashSet<Equipment>();
        }

        public string NameTypeEquipment { get; set; } = null!;

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}
