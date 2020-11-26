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
    public class PeopleController : ControllerBase
    {
        StudentRepository _StudentsRepo;
        ParentRepository _ParentsRepo;
        TeacherRepository _TeachersRepo;
        public PeopleController(StudentRepository repo_student, ParentRepository repo_parent, TeacherRepository repo_teacher)
        {
            _StudentsRepo = repo_student;
            _ParentsRepo = repo_parent;
            _TeachersRepo = repo_teacher;
        }

        [HttpPost]
        [Route("GetStudentsByParentId")]
        public ActionResult<List<StudentDTO>> GetStudentsByParentId(BasicRequest request)
        {
            return new JsonResult(_StudentsRepo.GetStudentsByParentId(request.ParentId));
        }

        [HttpPost]
        [Route("GetStudentsByGroupId")]
        public ActionResult<List<StudentDTO>> GetStudentsByGroupId(BasicRequest request)
        {
            return new JsonResult(_StudentsRepo.GetStudentsByGroupId(request.ParentId));

        }


        [HttpPost]
        [Route("CreateStudent")]
        public bool CreateStudent(NewPersonDTO request)
        {
            try
            {
                return _StudentsRepo.CreateStudent(request);
            }
            catch (Exception)
            {

                return false;
            }
        }


        [HttpPost]
        [Route("CreatePArent")]
        public bool CreateParent(NewPersonDTO request)
        {
            try
            {
                return _ParentsRepo.CreateParent(request);
            }
            catch (Exception)
            {

                return false;
            }
        }


        [HttpPost]
        [Route("CreateTeacher")]
        public bool CreateTeacher(NewPersonDTO request)
        {
            try
            {
                return _TeachersRepo.CreateTeacher(request);
            }
            catch (Exception)
            {

                return false;
            }
        }


        [HttpPost]
        [Route("GetAllStudents")]
        public List<Student> GetAllStudents()
        {
            return _StudentsRepo.GetAllStudents();
        }
    }
}
