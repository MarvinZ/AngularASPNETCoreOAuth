using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api
{
    public partial class Group
    {
        public int Id { get; set; }
        public int CycleId { get; set; }
        public int LevelId { get; set; }
        public string GroupShortname { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Cycle Cycle { get; set; }
        public virtual Level Level { get; set; }
    }
}
