﻿using System;
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
        public DateTime CreateDatetime { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public string CreateUser { get; set; }
        public string Status { get; set; }
         
        public List<TeacherDTO> Teachers { get; set; }

        public int TotalStudents { get; set; }



    }
}
