﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class Parent
    {
        public Parent()
        {
            Payments = new HashSet<Payment>();
            StudentParents = new HashSet<StudentParent>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public string Address { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<StudentParent> StudentParents { get; set; }
    }
}
