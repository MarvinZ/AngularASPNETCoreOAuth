﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class Group
    {
        public Group()
        {
            Activities = new HashSet<Activity>();
            Documents = new HashSet<Document>();
            GroupStudents = new HashSet<GroupStudent>();
            GroupTeachers = new HashSet<GroupTeacher>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CycleId { get; set; }
        public int LevelId { get; set; }
        public int GroupStatusId { get; set; }
        public string GroupShortname { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Client Client { get; set; }
        public virtual Cycle Cycle { get; set; }
        public virtual GroupStatus GroupStatus { get; set; }
        public virtual Level Level { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
        public virtual ICollection<GroupTeacher> GroupTeachers { get; set; }
    }
}
