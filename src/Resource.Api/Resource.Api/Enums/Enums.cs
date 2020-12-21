using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resource.Api.Enums
{
    enum GroupStatusEnum
    {
        Active = 1,    // 0
        NotActive = 2
    }

    enum PaymentStatusEnum
    {
        New = 1,    // 0
        InReview = 2,
        Paid = 3,
        Cancelled = 4
    }
}
