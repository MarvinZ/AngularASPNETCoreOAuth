using System;

namespace Resource.Api.Controllers
{

    public class basicRequest
    {
        public int ParentId { get; set; }
        public int GroupId { get; set; }
        public DateTime requestDate { get; set; }

    }
    public class newPersonDTO
    {
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public DateTime requestDate { get; set; }
    }

    public class newThingDTO
    {

        public DateTime requestDate { get; set; }
    }

}