using System;
using System.Collections.Generic;

namespace Resource.Api
{
    public class ParentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }

        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }

        // more

        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<StudentDTO> Kids { get; set; }

    }
}