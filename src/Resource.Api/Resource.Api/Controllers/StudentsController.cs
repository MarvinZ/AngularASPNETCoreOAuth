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
    public class StudentsController : ControllerBase
    {
        NinjaRepository _repo;
        public StudentsController(NinjaRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("GetStudentsByParentId")]
        public ActionResult<IEnumerable<string>> GetStudentsByParentId(requestDTO request)
        {
            using (var context = new Kinder2021Context())
            {
                var students = context.Students.Join(context.StudentParents, student => student.Id,
                    studentParent => studentParent.Student.Id,
                                    (student, studentParent) => new {
                                        Name = student.Name,
                                        Lastname = student.LastName1,
                                        ParentId = studentParent.ParentId
                                    }).Where(e => e.ParentId == request.ParentId).ToList();


                return new JsonResult(students);
            }
        }

        [HttpPost]
        [Route("GetStudentsByGroupId")]
        public ActionResult<IEnumerable<string>> GetStudentsByGroupId(requestDTO request)
        {
            using (var context = new Kinder2021Context())
            {
                var students = context.Students.Join(context.GroupStudents, student => student.Id,
                    groupStudent => groupStudent.Student.Id,
                                    (student, groupStudents) => new {
                                        Name = student.Name,
                                        Lastname = student.LastName1,
                                        GroupId = groupStudents.GroupId
                                    }).Where(e => e.GroupId == request.GroupId).ToList();


                return new JsonResult(students);
            }
        }


        [HttpPost]
        [Route("CreateStudent")]
        public bool CreateStudent(newStudentDTO request)
        {
            try
            {
                using (var context = new Kinder2021Context())
                {
                    var student = new Student()
                    {
                        CreateDatetime = DateTime.UtcNow,
                        Name = request.Name,
                        LastName1 = request.LastName1,
                        LastName2 = request.LastName1,
                        Birthday = Convert.ToDateTime("2018-12-1"),
                        CreateUser = "Admin",
                        RegistrationDate = DateTime.UtcNow

                    };
                    context.Students.Add(student);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
           
        }


        [HttpPost]
        [Route("GetAllStudents")]
        public List<Student> GetAllStudents (newStudentDTO request)
        {
            return _repo.GetAllNinjas();
        }
    }
}
