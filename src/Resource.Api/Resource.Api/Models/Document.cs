using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public string FileLocation { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Group Group { get; set; }
        public virtual Student Student { get; set; }
    }
}
