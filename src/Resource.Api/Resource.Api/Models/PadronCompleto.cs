using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api.Models
{
    public partial class PadronCompleto
    {
        public int Cedula { get; set; }
        public int Codelec { get; set; }
        public int FechaCaduc { get; set; }
        public int Column4 { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
    }
}
