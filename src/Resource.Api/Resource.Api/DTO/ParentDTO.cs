using System;

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
 
        public string LastName1 { get; internal set; }
        public string LastName2 { get; internal set; }
    }
}