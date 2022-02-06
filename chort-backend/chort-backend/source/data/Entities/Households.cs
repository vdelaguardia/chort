using System;
using System.Collections.Generic;

namespace chort_backend.source.data.entities
{
    public partial class Households
    {
        public Households()
        {
            ScheduledChores = new HashSet<ScheduledChores>();
        }

        public string Id { get; set; } = null!;
        public string? OwnerId { get; set; }

        public virtual Users? Owner { get; set; }
        public virtual ICollection<ScheduledChores> ScheduledChores { get; set; }
    }
}
