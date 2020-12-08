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
        StudentsRepository _StudentsRepo;
        ParentsRepository _ParentsRepo;
        TeachersRepository _TeachersRepo;
        public PeopleController(StudentsRepository repo_student, ParentsRepository repo_parent, TeachersRepository repo_teacher)
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
            return new JsonResult(_StudentsRepo.GetStudentsByGroupId(request.GroupId));

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

        [HttpPost]
        [Route("GetStudentDetails")]
        public StudentDTO GetStudentDetails(StudentRequestDTO request)
        {
            return _StudentsRepo.GetStudentDetails(request.StudentId);
        }



        [HttpPost]
        [Route("AddStudent")]
        public bool CreateGroup(NewPersonDTO request)
        {
            try
            {
                return _StudentsRepo.AddStudent(request.Name, request.LastName1, request.LastName2, request.Birthday, request.Genre);
            }
            catch (Exception e)
            {

                return false;
            }

        }
    }
}
