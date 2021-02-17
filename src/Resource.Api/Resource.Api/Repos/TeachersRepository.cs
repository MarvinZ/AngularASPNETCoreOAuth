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

        public List<TeacherDTO> GetAllAvailableTeachers(int groupId)
        {
            var tempRes = _context.Teachers.Select(e => new TeacherDTO
            {
                Id = e.Id,
                Name = e.Name + " " + e.LastName1 + " " + e.LastName2
            }).ToList();

            return tempRes;
        }


        public TeacherDTO GetTeacherDetails(int teacherId)
        {
            try
            {

                var tempRes = _context.Teachers.Where(e => e.Id == teacherId).Select(teacher => new TeacherDTO
                {
                    Id = teacher.Id,
                    Birthday = teacher.Birthday,
                    RegistrationDate = teacher.RegistrationDate,
                    Name = teacher.Name,
                    LastName1 = teacher.LastName1,
                    LastName2 = teacher.LastName2,
                    Cedula = teacher.CountryId,
                    Lastnames = teacher.LastName1 + " " + teacher.LastName2,
                    Genre = char.Parse(teacher.Gender)

                }).FirstOrDefault();

                if (tempRes != null)
                {
                    //FIX ME FIX ME!!!! teadcherid
                    var profilePic = _context.Documents
                        .Where(e => e.TeacherId == teacherId && e.IsProfilePic == true).OrderByDescending(e => e.Id).FirstOrDefault();
                    tempRes.ProfilePic = profilePic?.Title;


                    var groups = _context.Groups.Join(_context.GroupTeachers.Where(e => e.TeacherId == teacherId && e.DeactivateDatetime == null),
                        group => group.Id,
                        groupTeacher => groupTeacher.GroupId,
                        (group, groupTeacher) => new GroupDTO
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

                        foreach (var par in groups)
                        {
                            tempRes.Groups.Add(par);
                        }
                    }

                }
                return tempRes;

            }
            catch (Exception e)
            {

                return null;
            }
        }



        public bool AddTeacher(int clientId, string name, string lastName1, string lastName2, DateTime birthday, char genre, string email, string phone)
        {

            try
            {
                var newTeacher = new Teacher()
                {
                    ClientId = clientId,
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