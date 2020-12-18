using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class FinancialDTO
    {
        public int Id { get; set; }

        public decimal RequestedAmount { get; set; }
        public decimal? PaidAmount { get; set; }

        public string PaymentStatusName { get; set; }
        public string PaymentRequestTypeName { get; set; }
        public string PaidBy { get; set; }
        public string StudentName { get; set; }

        public DateTime RequestedTime { get; set; }
        public DateTime? PaidTime { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }

    }
}
