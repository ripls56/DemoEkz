using System;
using System.Collections.Generic;

namespace DemoEkz.models
{
    public partial class Equipment
    {
        public Equipment()
        {
            OperationSpecifications = new HashSet<OperationSpecification>();
        }

        public string NameEquipment { get; set; } = null!;
        public string TypeEquipmentName { get; set; } = null!;
        public string DegreeOfWear { get; set; } = null!;
        public DateTime AcquisitionDate { get; set; }
        public string DescriptionEquipment { get; set; } = null!;

        public virtual TypeEquipment TypeEquipmentNameNavigation { get; set; } = null!;
        public virtual ICollection<OperationSpecification> OperationSpecifications { get; set; }
    }
}
