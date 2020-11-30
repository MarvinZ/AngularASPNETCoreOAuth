using System;

namespace Resource.Api
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
        public DateTime RequestDate { get; set; }
    }

    public class NewThingDTO
    {
        public DateTime requestDate { get; set; }
    }

    public class NewPaymentDTO
    {
        public int ParentId { get; set; }

        public decimal Amount { get; set; }

        public DateTime RequestDate { get; set; }
    }


    public class GroupRequestDTO
    {
        public int groupId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime requestDate { get; set; }
    }

}