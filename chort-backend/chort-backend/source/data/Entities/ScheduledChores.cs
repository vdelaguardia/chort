using System;
using System.Collections.Generic;

namespace chort_backend.source.data.entities
{
    public partial class ScheduledChores
    {
        public ScheduledChores()
        {
            ChoreEvents = new HashSet<ChoreEvents>();
        }

        public string Id { get; set; } = null!;
        public string? HouseholdId { get; set; }
        public string? AssigneeId { get; set; }
        public string? Name { get; set; }
        public int? Difficulty { get; set; }
        public int? Frequency { get; set; }

        public virtual Users? Assignee { get; set; }
        public virtual FrequencyScheduledChores? FrequencyNavigation { get; set; }
        public virtual Households? Household { get; set; }
        public virtual ICollection<ChoreEvents> ChoreEvents { get; set; }
    }
}
