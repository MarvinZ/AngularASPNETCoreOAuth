using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Resource.Api.Models;

namespace Resource.Api.Controllers
{
   // [Authorize(Policy = "ApiReader")]
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        GroupRepository _GroupsRepo;
        public ThingsController(GroupRepository GroupsRepo)
        {
            _GroupsRepo = GroupsRepo;
        }

        


        [HttpPost]
        [Route("CreateGroup")]
        public bool CreateGroup(newThingDTO request)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }


        [HttpPost]
        [Route("GetAllGroups")]
        public List<Group> GetAllGroups ()
        {
            return _GroupsRepo.GetAllGroups();
        }
    }
}
