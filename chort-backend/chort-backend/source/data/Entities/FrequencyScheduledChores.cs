using System;
using System.Collections.Generic;

namespace chort_backend.Entities
{
    public partial class FrequencyScheduledChores
    {
        public FrequencyScheduledChores()
        {
            ScheduledChores = new HashSet<ScheduledChores>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ScheduledChores> ScheduledChores { get; set; }
    }
}
