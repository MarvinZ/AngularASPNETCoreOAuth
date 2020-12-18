using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class PaymentRequest
    {
        public PaymentRequest()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StudentId { get; set; }
        public int PaymentRequestTypeId { get; set; }
        public int PaymentStatusId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Client Client { get; set; }
        public virtual PaymentRequestType PaymentRequestType { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
