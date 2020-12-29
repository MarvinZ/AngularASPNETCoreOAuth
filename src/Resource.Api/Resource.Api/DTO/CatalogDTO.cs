using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class CatalogDTO
    {
        public List<Level> Levels { get; set; }
        public List<StateOrProvince> Provinces { get; set; }
        public List<Canton> Cities { get; set; }
        public List<Distrito> Distritos { get; set; }
        public List<Cycle> Cycles { get; set; }
        public List<PaymentType> PaymentTypes { get; set; }
        public List<ActivityType> ActivityTypes { get; set; }
    }
}
