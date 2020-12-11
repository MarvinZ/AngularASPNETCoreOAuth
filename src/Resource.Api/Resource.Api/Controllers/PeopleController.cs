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

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
        //[HttpPost]
        //[Route("CreateStudent")]
        //public bool CreateStudent(NewPersonDTO request)
        //{
        //    try
        //    {
        //        return _StudentsRepo.CreateStudent(request);
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
        //[HttpPost]
        //[Route("CreateParent")]
        //public bool CreateParent(NewPersonDTO request)
        //{
        //    try
        //    {
        //        return _ParentsRepo.CreateParent(request);
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
        //[HttpPost]
        //[Route("CreateTeacher")]
        //public bool CreateTeacher(NewPersonDTO request)
        //{
        //    try
        //    {
        //        return _TeachersRepo.CreateTeacher(request);
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 
        [HttpPost]
        [Route("GetAllStudents")]
        public List<Student> GetAllStudents()
        {
            return _StudentsRepo.GetAllStudents();
        }

        [HttpPost]
        [Route("GetAllParents")]
        public List<Parent> GetAllParents()
        {
            return _ParentsRepo.GetAllParents();
        }

        [HttpPost]
        [Route("GetAllTeachers")]
        public List<Teacher> GetAllTeachers()
        {
            return _TeachersRepo.GetAllTeachers();
        }


        [HttpPost]
        [Route("GetAllAvailableTeachers")]
        public List<TeacherDTO> GetAllAvailableTeachers( GroupRequestDTO request)
        {
            return _TeachersRepo.GetAllAvailableTeachers( request.GroupId);
        }



        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 

        [HttpPost]
        [Route("GetStudentDetails")]
        public StudentDTO GetStudentDetails(StudentRequestDTO request)
        {
            return _StudentsRepo.GetStudentDetails(request.StudentId);
        }

        [HttpPost]
        [Route("GetParentDetails")]
        public ParentDTO GetParentDetails(ParentRequestDTO request)
        {
            return _ParentsRepo.GetParentDetails(request.ParentId);
        }

        [HttpPost]
        [Route("GetTeacherDetails")]
        public TeacherDTO GetTeacherDetails(TeacherRequestDTO request)
        {
            return _TeachersRepo.GetTeacherDetails(request.TeacherId);
        }

        /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// /// 


        [HttpPost]
        [Route("AddStudent")]
        public bool AddStudent(NewPersonDTO request)
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


        [HttpPost]
        [Route("AddParent")]
        public bool AddParent(NewPersonDTO request)
        {
            try
            {
                return _ParentsRepo.AddParentForStudent(request.Name, request.LastName1, request.LastName2, 
                                            request.Birthday, request.Genre, request.Email, request.Phone, request.StudentId);
            }
            catch (Exception e)
            {

                return false;
            }

        }


        [HttpPost]
        [Route("AddTeacher")]
        public bool AddTeacher(NewPersonDTO request)
        {
            try
            {
                return _TeachersRepo.AddTeacher(request.Name, request.LastName1, request.LastName2, request.Birthday, request.Genre, request.Email, request.Phone);
            }
            catch (Exception e)
            {

                return false;
            }

        }



        [HttpPost]
        [Route("AddTeacherToGroup")]
        public bool AddTeacherToGroup(RelationshipRequestDTO request)
        {
            try
            {
                return _TeachersRepo.AddTeacherToGroup(request.TeacherId, request.GroupId);
            }
            catch (Exception e)
            {
                return false;
            }

        }

        [HttpPost]
        [Route("AddStudentToGroup")]
        public bool AddStudentToGroup(RelationshipRequestDTO request)
        {
            try
            {
                return _StudentsRepo.AddStudentToGroup(request.StudentId, request.GroupId);
            }
            catch (Exception e)
            {
                return false;
            }

        }

        [HttpPost]
        [Route("AddParentToStudent")]
        public bool AddParentToStudent(RelationshipRequestDTO request)
        {
            try
            {
                return _StudentsRepo.AddParentToStudent(request.StudentId, request.ParentId);
            }
            catch (Exception e)
            {
                return false;
            }

        }

        [HttpPost]
        [Route("RemoveTeacherFromGroup")]
        public bool RemoveTeacherFromGroup(RelationshipRequestDTO request)
        {
            try
            {
                return _TeachersRepo.RemoveTeacherFromGroup(request.TeacherId, request.GroupId);
            }
            catch (Exception e)
            {
                return false;
            }

        }

        [HttpPost]
        [Route("RemoveStudentFromGroup")]
        public bool RemoveStudentFromGroup(RelationshipRequestDTO request)
        {
            try
            {
                return _StudentsRepo.RemoveStudentFromGroup(request.StudentId, request.GroupId);
            }
            catch (Exception e)
            {
                return false;
            }

        }

        [HttpPost]
        [Route("RemoveParentFromStudent")]
        public bool RemoveParentFromStudent(RelationshipRequestDTO request)
        {
            try
            {
                return _StudentsRepo.RemoveParentFromStudent(request.StudentId, request.ParentId);
            }
            catch (Exception e)
            {
                return false;
            }

        }



        [HttpPost]
        [Route("GetNameFromCedula")]
        public NameDTO GetNameFromCedula(PersonRequestDTO request)
        {
            return _ParentsRepo.GetNameFromCedula(request.Cedula);
        }


        [HttpPost]
        [Route("GetExistingNameFromCedula")]
        public NameDTO GetExistingNameFromCedula(PersonRequestDTO request)
        {
            return _ParentsRepo.GetExistingNameFromCedula(request.Cedula);
        }

        


    }
}
