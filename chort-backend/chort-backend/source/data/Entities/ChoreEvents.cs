using System;
using System.Collections.Generic;

namespace chort_backend.Entities
{
    public partial class ChoreEvents
    {
        public string Id { get; set; } = null!;
        public string? ScheduledChoreId { get; set; }
        public DateTime? CompletedDatetime { get; set; }

        public virtual ScheduledChores? ScheduledChore { get; set; }
    }
}
