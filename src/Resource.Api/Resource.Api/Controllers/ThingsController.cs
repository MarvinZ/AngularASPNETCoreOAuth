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
    //[Authorize(Policy = "ApiReader")]
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        DocumentRepository _DocumentsRepo;
        GroupRepository _GroupsRepo;
        public ThingsController(GroupRepository GroupsRepo, DocumentRepository DocumentsRepo)
        {
            _GroupsRepo = GroupsRepo;
            _DocumentsRepo = DocumentsRepo;
        }


        [HttpPost]
        [Route("CreateGroup")]
        public bool CreateGroup(NewThingDTO request)
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
        public List<GroupDTO> GetAllGroups()
        {
            return _GroupsRepo.GetAllGroups();
        }

        [HttpPost]
        [Route("EnrollStudent")]
        public bool EnrollStudent(GroupRequestDTO request)
        {
            return _GroupsRepo.EnrollStudent(request.groupId, request.StudentId);
        }

        [HttpPost]
        [Route("AssignTeacher")]
        public bool AssignTeacher(GroupRequestDTO request)
        {
            return _GroupsRepo.AssignTeacher(request.groupId, request.TeacherId);
        }

        [HttpPost]
        [Route("UnEnrollStudent")]
        public bool UnEnrollStudent(GroupRequestDTO request)
        {
            return _GroupsRepo.UnEnrollStudent(request.groupId, request.StudentId);
        }

        [HttpPost]
        [Route("UnAssignTeacher")]
        public bool UnAssignTeacher(GroupRequestDTO request)
        {
            return _GroupsRepo.UnAssignTeacher(request.groupId, request.TeacherId);
        }

        [HttpPost]
        [Route("GetAllDocumentsByStudent")] // and groupid...
        public List<Document> GetAllDocumentsByStudent(GroupRequestDTO request)
        {
            return _GroupsRepo.GetAllDocumentsByStudent(request.StudentId);
        }
    }
}
