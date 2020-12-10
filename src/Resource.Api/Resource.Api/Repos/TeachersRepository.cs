using Resource.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface ITeacherRepository
    {
        List<Teacher> GetAllTeachers();
    }


    public class TeachersRepository : ITeacherRepository
    {
        Kinder2021Context _context;
        public TeachersRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        public TeacherDTO GetTeacherDetails(int teacherId)
        {
            try
            {

                var tempRes = _context.Teachers.Where(e => e.Id == teacherId).Select(student => new TeacherDTO
                {
                    Id = student.Id,
                    Birthday = student.Birthday,
                    RegistrationDate = student.RegistrationDate,
                    Name = student.Name,
                    Lastnames = student.LastName1 + " " + student.LastName2,
                }).FirstOrDefault();

                if (tempRes != null)
                {
                    var parents = _context.Parents.Join(_context.StudentParents.Where(e => e.StudentId == teacherId),
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

                    var groups = _context.Groups.Join(_context.GroupStudents.Where(e => e.StudentId == teacherId),
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



        public bool AddTeacher(string name, string lastName1, string lastName2, DateTime birthday, char genre, string email, string phone)
        {

            try
            {
                var newTeacher = new Teacher()
                {

                    Name = name,
                    LastName2 = lastName2,
                    LastName1 = lastName1,
                    Birthday = birthday,
                    RegistrationDate = DateTime.UtcNow,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "ADMIN",
                    Address = "some address that should not be here...",
                    Email = email,
                    Phone = phone,
                    CountryId = "IDIOTA"
                };
                _context.Teachers.Add(newTeacher);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool AddTeacherToGroup(int teacherId, int groupId)
        {
            try
            {
                var newRelationship = new GroupTeacher()
                {
                    TeacherId = teacherId,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "ADMIN",
                    GroupId = groupId
                };
                _context.GroupTeachers.Add(newRelationship);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public bool RemoveTeacherFromGroup(int teacherId, int groupId)
        {
            try
            {
                var deleteMe = _context.GroupTeachers.Where(e => e.TeacherId == teacherId && e.GroupId == groupId).FirstOrDefault();
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



}