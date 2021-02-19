using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class PaymentRequest
    {
        public PaymentRequest()
        {
            Documents = new HashSet<Document>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StudentId { get; set; }
        public int PaymentStatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Client Client { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
