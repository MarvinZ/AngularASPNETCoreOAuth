using Microsoft.EntityFrameworkCore;
using Resource.Api.Controllers;
using Resource.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IStudentRepository
    {
        List<StudentDTO> GetAllStudents();
    }


    public class StudentsRepository : IStudentRepository
    {
        Kinder2021Context _context;
        public StudentsRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<StudentDTO> GetAllStudents()
        {



            try
            {
                var tempRes = _context.Students.Where(e => e.DeactivateDatetime == null).Select(student => new StudentDTO
                {
                    Id = student.Id,
                    Birthday = student.Birthday,
                    RegistrationDate = student.RegistrationDate,
                    Name = student.Name,
                    Lastnames = student.LastName1 + " " + student.LastName2,
                    ProfilePic = ""
                }).ToList();


                if (tempRes.Count > 0)
                {

                    foreach (var item in tempRes)
                    {
                        var profilePic = _context.Documents
                      .Where(e => e.StudentId == item.Id && e.IsProfilePic == true).OrderByDescending(e => e.Id).FirstOrDefault();
                        item.ProfilePic = profilePic?.Title;

                        var parents = _context.Parents.Join(_context.StudentParents.Where(e => e.StudentId == item.Id && e.DeactivateDatetime == null),
                            parent => parent.Id,
                            studentParent => studentParent.ParentId,
                            (parent, studentParent) => new ParentDTO
                            {
                                Id = parent.Id,
                                Email = parent.Email,
                                Name = parent.Name,
                                Lastnames = parent.LastName1 + " " + parent.LastName2,
                            }).ToList();

                        if (parents != null)
                        {
                            item.Parents = new List<ParentDTO>();

                            foreach (var par in parents)
                            {
                                item.Parents.Add(par);
                            }
                        }

                        var groups = _context.Groups.Join(_context.GroupStudents.Where(e => e.StudentId == item.Id && e.DeactivateDatetime == null),
                            group => group.Id,
                            groupStudent => groupStudent.GroupId,
                            (group, groupStudent) => new GroupDTO
                            {
                                Id = group.Id,
                                GroupShortname = group.GroupShortname,
                                LevelName = group.Level.Name,
                                CycleName = group.Cycle.Name,
                                Status = "ACTIVEXXX"
                            }).ToList();

                        if (groups != null)
                        {
                            item.Groups = new List<GroupDTO>();

                            foreach (var g in groups)
                            {
                                item.Groups.Add(g);
                            }
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

        public List<StudentDTO> GetStudentsByParentId(int parentId)
        {
            var students = _context.Students.Join(_context.StudentParents.Where(e => e.ParentId == parentId && e.DeactivateDatetime == null), student => student.Id,
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
            var students = _context.Students.Join(_context.GroupStudents.Where(e => e.GroupId == groupId && e.DeactivateDatetime == null), student => student.Id,
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
                    ProfilePic = ""
                }).FirstOrDefault();


                if (tempRes != null)
                {
                    var profilePic = _context.Documents
                        .Where(e => e.StudentId == studentId && e.IsProfilePic == true).OrderByDescending(e=> e.Id).FirstOrDefault();
                    tempRes.ProfilePic = profilePic?.Title;

                    var parents = _context.Parents.Join(_context.StudentParents.Where(e => e.StudentId == studentId && e.DeactivateDatetime == null),
                        parent => parent.Id,
                        studentParent => studentParent.ParentId,
                        (parent, studentParent) => new ParentDTO
                        {
                            Id = parent.Id,
                            Email = parent.Email,
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

                    var groups = _context.Groups.Join(_context.GroupStudents.Where(e => e.StudentId == studentId && e.DeactivateDatetime == null),
                        group => group.Id,
                        groupStudent => groupStudent.GroupId,
                        (group, groupStudent) => new GroupDTO
                        {
                            Id = group.Id,
                            GroupShortname = group.GroupShortname,
                            LevelName = group.Level.Name,
                            CycleName = group.Cycle.Name,
                            Status = "ACTIVEXXX"
                        }).ToList();

                    if (groups != null)
                    {
                        tempRes.Groups = new List<GroupDTO>();

                        foreach (var g in groups)
                        {
                            tempRes.Groups.Add(g);
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

        public bool AddStudent(int clientId, string name, string lastName1, string lastName2, DateTime birthday, char genre)
        {

            try
            {
                var newStudent = new Student()
                {
                    ClientId = clientId,
                    Gender = genre.ToString(),
                    Name = name,
                    LastName2 = lastName2,
                    LastName1 = lastName1,
                    Birthday = birthday,
                    RegistrationDate = DateTime.UtcNow,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "ADMIN"
                };
                _context.Students.Add(newStudent);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool AddStudentToGroup(int studentId, int groupId)
        {
            try
            {
                var newRelationship = new GroupStudent()
                {
                    StudentId = studentId,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "ADMIN",
                    GroupId = groupId
                };
                _context.GroupStudents.Add(newRelationship);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool AddParentToStudent(int studentId, int parentId)
        {
            try
            {
                var newRelationship = new StudentParent()
                {
                    StudentId = studentId,
                    ParentId = parentId,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "ADMIN"
                };
                _context.StudentParents.Add(newRelationship);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool RemoveStudentFromGroup(int studentId, int groupId)
        {
            try
            {
                GroupStudent deleteMe = _context.GroupStudents.Where(e => e.StudentId == studentId && e.GroupId == groupId && e.DeactivateDatetime == null).FirstOrDefault();
                if (deleteMe != null)
                {
                    deleteMe.DeactivateDatetime = DateTime.UtcNow;
                    deleteMe.DeactivateUser = "ADMIN";
                }
                _context.SaveChanges();

                return true;

            }
            catch (Exception e)
            {

                return false;
            }
        }

        internal bool RemoveParentFromStudent(int studentId, int parentId)
        {
            try
            {
                var deleteMe = _context.StudentParents.Where(e => e.StudentId == studentId && e.ParentId == parentId && e.DeactivateDatetime == null).FirstOrDefault();
                if (deleteMe != null)
                {
                    deleteMe.DeactivateDatetime = DateTime.UtcNow;
                    deleteMe.DeactivateUser = "ADMIN";
                }

                _context.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

} // end of calss
  //end of namespace