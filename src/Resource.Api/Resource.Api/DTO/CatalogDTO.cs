using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class CatalogDTO
    {
        public List<Level> Levels { get; set; }
        public List<Cycle> Cycles { get; set; }
    }
}
