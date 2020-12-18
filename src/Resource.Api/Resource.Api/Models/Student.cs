using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class Student
    {
        public Student()
        {
            Activities = new HashSet<Activity>();
            Documents = new HashSet<Document>();
            GroupStudents = new HashSet<GroupStudent>();
            PaymentRequests = new HashSet<PaymentRequest>();
            StudentParents = new HashSet<StudentParent>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
        public virtual ICollection<PaymentRequest> PaymentRequests { get; set; }
        public virtual ICollection<StudentParent> StudentParents { get; set; }
    }
}
