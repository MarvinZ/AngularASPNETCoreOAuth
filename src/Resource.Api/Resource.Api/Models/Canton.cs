using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class Canton
    {
        public Canton()
        {
            Distritos = new HashSet<Distrito>();
            PhysicalAddresses = new HashSet<PhysicalAddress>();
        }

        public int Id { get; set; }
        public int StateOrProvinceId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string LastModifiedUser { get; set; }
        public DateTime? LastModificationDatetime { get; set; }
        public DateTime? DeactivateDatetime { get; set; }
        public string DeactivateUser { get; set; }

        public virtual StateOrProvince StateOrProvince { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; }
        public virtual ICollection<PhysicalAddress> PhysicalAddresses { get; set; }
    }
}
