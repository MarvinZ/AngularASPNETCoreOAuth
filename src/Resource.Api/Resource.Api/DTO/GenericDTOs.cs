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
        public string LastName2 { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public char Genre { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RequestDate { get; set; }

        public int StudentId { get; set; }

    }

    public class NewThingDTO
    {
        public DateTime requestDate { get; set; }
    }

    public class NewGroupDTO
    {
        public int LevelId { get; set; }
        public int CycleId { get; set; }
        public string ShortName { get; set; }
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
        public int GroupId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime requestDate { get; set; }
    }


    public class NameDTO
    {
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public int Cedula { get; set; }
    }

    public class PersonRequestDTO
    {
        public int Cedula { get; set; }
    }


    public class StudentRequestDTO
    {
        public int StudentId { get; set; }
        public DateTime requestDate { get; set; }
    }

    public class TeacherRequestDTO
    {

        public int TeacherId { get; set; }

        public DateTime requestDate { get; set; }
    }
    public class ParentRequestDTO
    {

        public int ParentId { get; set; }

        public DateTime requestDate { get; set; }
    }


    public class RelationshipRequestDTO
    {

        public int ParentId { get; set; }
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }

        public DateTime requestDate { get; set; }
    }

}