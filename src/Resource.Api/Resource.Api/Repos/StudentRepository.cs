using Resource.Api.Controllers;
using Resource.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
    }


    public class StudentRepository : IStudentRepository
    {
        Kinder2021Context _context;
        public StudentRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public List<StudentDTO> GetStudentsByParentId(int parentId)
        {
            var students = _context.Students.Join(_context.StudentParents.Where(e => e.ParentId == parentId), student => student.Id,
                studentParent => studentParent.Student.Id,
                                (student, studentParent) => new StudentDTO
                                {
                                    Name = student.Name,
                                    Lastnames = student.LastName1 + " " + student.LastName2,
                                    ParentId = studentParent.ParentId
                                }).ToList();
            return students;
        }

        public List<StudentDTO> GetStudentsByGroupId(int groupId)
        {
            var students = _context.Students.Join(_context.GroupStudents.Where(e => e.GroupId == groupId), student => student.Id,
          groupStudent => groupStudent.Student.Id,
                          (student, groupStudents) => new StudentDTO
                          {
                              Name = student.Name,
                              Lastnames = student.LastName1 + " " + student.LastName2,
                          }).ToList();
            return students;
        }

        public bool CreateStudent(NewPersonDTO request)
        {
            try
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
                _context.Students.Add(student);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    } // end of calss
} //end of namespace