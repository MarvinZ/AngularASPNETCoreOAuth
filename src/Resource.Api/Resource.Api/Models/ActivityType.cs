using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
