using System;

namespace Resource.Api
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastnames { get; set; }
 
        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }

        // more

        public int ParentId { get; set; }
    }
}