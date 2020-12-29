using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class PhysicalAddress
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int StateOrProvinceId { get; set; }
        public int? CantonId { get; set; }
        public int? DistritoId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string ZipCode { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual Canton Canton { get; set; }
        public virtual Country Country { get; set; }
        public virtual Distrito Distrito { get; set; }
        public virtual StateOrProvince StateOrProvince { get; set; }
    }
}
