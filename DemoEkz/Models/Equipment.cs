using System;
using System.Collections.Generic;

namespace DemoEkz.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            OperationSpecifications = new HashSet<OperationSpecification>();
        }

        public string NameEquipment { get; set; } = null!;
        public string TypeEquipmentName { get; set; } = null!;
        public string DescriptionEquipment { get; set; } = null!;

        public virtual TypeEquipment TypeEquipmentNameNavigation { get; set; } = null!;
        public virtual ICollection<OperationSpecification> OperationSpecifications { get; set; }
    }
}
