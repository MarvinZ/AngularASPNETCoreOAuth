using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class Client
    {
        public Client()
        {
            Activities = new HashSet<Activity>();
            Documents = new HashSet<Document>();
            Groups = new HashSet<Group>();
            Parents = new HashSet<Parent>();
            PaymentRequests = new HashSet<PaymentRequest>();
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DomainName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
        public virtual ICollection<PaymentRequest> PaymentRequests { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
