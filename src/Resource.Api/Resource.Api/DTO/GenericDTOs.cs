using System;

namespace Resource.Api.Controllers
{

    public class BasicRequest
    {
        public int ParentId { get; set; }
        public int GroupId { get; set; }
        public DateTime requestDate { get; set; }

    }
    public class NewPersonDTO
    {
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public DateTime requestDate { get; set; }
    }

    public class NewThingDTO
    {
        public DateTime requestDate { get; set; }
    }

}