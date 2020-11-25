using System;

namespace Resource.Api.Controllers
{
    public class requestDTO
    {
        public int ParentId { get; set; }
        public int GroupId { get; set; }
        public DateTime requestDate { get; set; }
    }
}