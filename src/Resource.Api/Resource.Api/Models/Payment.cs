﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int PaymentRequestId { get; set; }
        public int ParentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual PaymentRequest PaymentRequest { get; set; }
    }
}
