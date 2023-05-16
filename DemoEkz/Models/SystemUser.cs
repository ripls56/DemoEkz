using System;
using System.Collections.Generic;

namespace DemoEkz.Models
{
    public partial class SystemUser
    {
        public SystemUser()
        {
            UserOrderEmployeeSystemUsers = new HashSet<UserOrder>();
            UserOrderSystemUsers = new HashSet<UserOrder>();
        }

        public string LoginSystemUser { get; set; } = null!;
        public string PasswordSystemUser { get; set; } = null!;
        public string NameRoleSystemUser { get; set; } = null!;
        public string? SurenameSystemUser { get; set; }
        public string? NameSystemUser { get; set; }
        public string? LastnameSystemUser { get; set; }
        public byte[]? PhotoSystemUser { get; set; }
        public string? PhotoTypeSystemUser { get; set; }

        public virtual ICollection<UserOrder> UserOrderEmployeeSystemUsers { get; set; }
        public virtual ICollection<UserOrder> UserOrderSystemUsers { get; set; }
    }
}
