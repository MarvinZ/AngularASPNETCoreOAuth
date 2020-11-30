using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class PaymentDTO
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string StudentName { get; set; }

        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }

    }
}
