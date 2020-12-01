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


    public class StudentsRepository : IStudentRepository
    {
        Kinder2021Context _context;
        public StudentsRepository(Kinder2021Context context)
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
                              Id = student.Id,
                              Birthday = student.Birthday,
                              RegistrationDate = student.RegistrationDate,
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
                    LastName2 = request.LastName2,
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

        public StudentDTO GetStudentDetails(int studentId)
        {
            try
            {
                var result = new StudentDTO();
                var tempRes = _context.Students.Where(e => e.Id == studentId).Select(student => new StudentDTO
                {
                    Id = student.Id,
                    Birthday = student.Birthday,
                    RegistrationDate = student.RegistrationDate,
                    Name = student.Name,
                    Lastnames = student.LastName1 + " " + student.LastName2,
                }).FirstOrDefault();

                if (tempRes != null)
                {
                    var parents = _context.Parents.Join(_context.StudentParents.Where(e => e.StudentId == studentId),
                        parent => parent.Id,
                        studentParent => studentParent.ParentId,
                        (parent, studentParent) => new ParentDTO
                        {
                            Name = parent.Name,
                            Lastnames = parent.LastName1 + " " + parent.LastName2,
                        }).ToList();

                    if (parents != null)
                    {
                        tempRes.Parents = new List<ParentDTO>();

                        foreach (var par in parents)
                        {
                            tempRes.Parents.Add(par);
                        }
                    }
                }
                return tempRes;

            }
            catch (Exception)
            {

                return null;
            }
        }

    } // end of calss
} //end of namespace