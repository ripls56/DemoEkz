using System;
using System.Collections.Generic;

namespace DemoEkz.Models
{
    public partial class Product
    {
        public Product()
        {
            ArticulSpecifications = new HashSet<ArticulSpecification>();
            DecorCakeSpecifications = new HashSet<DecorCakeSpecification>();
            OperationSpecifications = new HashSet<OperationSpecification>();
            SemiProductSpecificationProductNameNavigations = new HashSet<SemiProductSpecification>();
            SemiProductSpecificationSemiProductNameNavigations = new HashSet<SemiProductSpecification>();
            UserOrders = new HashSet<UserOrder>();
        }

        public string NameProduct { get; set; } = null!;
        public int SizeProduct { get; set; }

        public virtual ICollection<ArticulSpecification> ArticulSpecifications { get; set; }
        public virtual ICollection<DecorCakeSpecification> DecorCakeSpecifications { get; set; }
        public virtual ICollection<OperationSpecification> OperationSpecifications { get; set; }
        public virtual ICollection<SemiProductSpecification> SemiProductSpecificationProductNameNavigations { get; set; }
        public virtual ICollection<SemiProductSpecification> SemiProductSpecificationSemiProductNameNavigations { get; set; }
        public virtual ICollection<UserOrder> UserOrders { get; set; }
    }
}
