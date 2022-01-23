using System;
using System.Collections.Generic;

namespace chort_backend.Entities
{
    public partial class Users
    {
        public Users()
        {
            Households = new HashSet<Households>();
            ScheduledChores = new HashSet<ScheduledChores>();
        }

        public string Id { get; set; } = null!;
        public string? Email { get; set; }

        public virtual ICollection<Households> Households { get; set; }
        public virtual ICollection<ScheduledChores> ScheduledChores { get; set; }
    }
}
