using System;
using System.Collections.Generic;

#nullable disable

namespace Resource.Api
{
    public partial class GroupDTO
    {
        public int Id { get; set; }

        public string CycleName { get; set; }

        public string LevelName { get; set; }
        public string GroupShortname { get; set; }
        public int AmountOfStudents { get; set; }
        public DateTime CreateDatetime { get; set; }
        public string CreateUser { get; set; }
        public string Status { get; set; }



    }
}
