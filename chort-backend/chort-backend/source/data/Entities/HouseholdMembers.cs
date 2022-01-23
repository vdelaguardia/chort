using System;
using System.Collections.Generic;

namespace chort_backend.Entities
{
    public partial class HouseholdMembers
    {
        public string? HouseholdId { get; set; }
        public string? MemberId { get; set; }

        public virtual Households? Household { get; set; }
        public virtual Users? Member { get; set; }
    }
}
