using System;
using System.Collections.Generic;

namespace Resource.Api
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }
        public string ProfilePic { get; set; }

        public char Genre { get; set; }
        public DateTime Birthday { get; set; }
        public string RegistrationDate { get; set; }

        // more

        public int ParentId { get; set; }
        public string LastName1 { get; internal set; }
        public string LastName2 { get; internal set; }

        public List<ParentDTO> Parents { get; internal set; }
        public List<GroupDTO> Groups { get; internal set; }



    }
}