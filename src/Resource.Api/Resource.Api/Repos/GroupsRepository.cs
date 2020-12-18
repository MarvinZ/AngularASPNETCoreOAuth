using Resource.Api.Enums;
using Resource.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IGroupRepository
    {
        List<GroupDTO> GetAllGroups();

        public bool EnrollStudent(int groupId, int studentId);
        public bool UnEnrollStudent(int groupId, int studentId);

        public bool AssignTeacher(int groupId, int teacherId);
        public bool UnAssignTeacher(int groupId, int teacherId);

        public List<Document> GetAllDocumentsByStudent(int studentId);

    }


    public class GroupsRepository : IGroupRepository
    {
        Kinder2021Context _context;
        public GroupsRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<GroupDTO> GetAllGroups()
        {

            //var result2 = _context.Groups.Where(e => e.DeactivateDatetime == null && e.GroupStatusId == (int)GroupStatusName.Active)
            //    .GroupJoin(_context.GroupTeachers.DefaultIfEmpty(), group => group.Id, gt => gt.GroupId,  

            var result = _context.Groups.Where(e => e.DeactivateDatetime == null && e.GroupStatusId == (int)GroupStatusName.Active)
               // .Join(_context.GroupTeachers.DefaultIfEmpty(), group => group.Id, gt => gt.GroupId,
               .Select ( group => new GroupDTO()
              //   (group, gt) => new GroupDTO

                 {
                     MaxDate = group.MaxDate,
                     MinDate = group.MinDate,
                     CreateUser = group.CreateUser,
                     CreateDatetime = group.CreateDatetime,
                     LevelName = group.Level.Name,
                     CycleName = group.Cycle.Name,
                     GroupShortname = group.GroupShortname,
                     Id = group.Id,
                     Status = group.GroupStatus.Name,
                     TotalStudents = group.GroupStudents.Count,
                     Teachers = group.GroupStudents.Count() == 0 ? null : group.GroupTeachers.Select(e => new TeacherDTO()
                     {
                         Name = e.Teacher.Name +" " + e.Teacher.LastName1 + " " + e.Teacher.LastName2,
                         Id = e.Teacher.Id
                     }).ToList()

                 }).ToList();



            return result;
        }

        public bool CreateGroup(int clientId, int levelId, int cycleId, string shortName, string min, string max)
        {
            try
            {
                var newGroup = new Group()
                {
                    ClientId = clientId,
                    LevelId = levelId,
                    CycleId = cycleId,
                    GroupShortname = shortName,
                    MaxDate = DateTime.Parse(max),
                    MinDate = DateTime.Parse(min),
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "ADMIN",
                    GroupStatusId = 1

                };
                _context.Groups.Add(newGroup);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        internal List<GroupDTO> GetAvailableGroups(int studentId)
        {
            try
            {
                var studentBirthday = _context.Students.Where(e => e.Id == studentId).FirstOrDefault().Birthday;
                var result = _context.Groups
                    .Where(e => e.MinDate < studentBirthday && e.MaxDate >= studentBirthday
                    && e.DeactivateDatetime == null && e.GroupStatusId == (int)GroupStatusName.Active)
                    .Select(c => new GroupDTO
                    {
                        MaxDate = c.MaxDate,
                        MinDate = c.MinDate,
                        CycleName = c.Cycle.Name,
                        CreateUser = c.CreateUser,
                        CreateDatetime = c.CreateDatetime,
                        LevelName = c.Level.Name,
                        GroupShortname = c.GroupShortname,
                        Id = c.Id,
                        Status = c.GroupStatus.Name,
                        TotalStudents = c.GroupStudents.Count
                    }).ToList();

                return result;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public bool EnrollStudent(int groupId, int studentId)
        {
            try
            {
                var newRecord = new GroupStudent()
                {
                    GroupId = groupId,
                    StudentId = studentId
                };
                _context.GroupStudents.Add(newRecord);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool UnEnrollStudent(int groupId, int studentId)
        {
            try
            {
                var deleteMe = _context.GroupStudents.Where(e => e.GroupId == groupId && e.StudentId == studentId).FirstOrDefault();
                if (deleteMe != null)
                {
                    deleteMe.DeactivateDatetime = DateTime.UtcNow;
                    deleteMe.DeactivateUser = "Admin";
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool AssignTeacher(int groupId, int teacherId)
        {
            try
            {
                var newRecord = new GroupTeacher()
                {
                    GroupId = groupId,
                    TeacherId = teacherId
                };
                _context.GroupTeachers.Add(newRecord);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public CatalogDTO GetCatalog()
        {
            var result = new CatalogDTO()
            {
                Cycles = _context.Cycles.Where(e => e.DeactivateDatetime == null).ToList(),
                Levels = _context.Levels.Where(e => e.DeactivateDatetime == null).ToList(),
                PaymentTypes = _context.PaymentTypes.Where(e => e.DeactivateDatetime == null).ToList()

            };
            return result;
        }

        public GroupDTO GetGroupDetails(int groupId)
        {
            try
            {
                var result = new GroupDTO();
                var tempRes = _context.Groups.Where(e => e.Id == groupId).Select(group => new GroupDTO
                {
                    Id = group.Id,
                    CycleName = group.Cycle.Name,
                    LevelName = group.Level.Name, 
                    TotalStudents = group.GroupStudents.Count,
                    GroupShortname = group.GroupShortname,
                    Status = group.GroupStatus.Name

                }).FirstOrDefault();

                if (tempRes != null)
                {
                    var teachers = _context.Teachers.Join(_context.GroupTeachers.Where(e => e.GroupId == groupId && e.DeactivateDatetime == null),
                        teacher => teacher.Id,
                        groupTeacher => groupTeacher.TeacherId,
                        (teacher, groupTeacher) => new TeacherDTO
                        {
                            Id = teacher.Id,
                            Name = teacher.Name + teacher.LastName1 + " " + teacher.LastName2,
                        }).ToList();

                    if (teachers != null)
                    {
                        tempRes.Teachers = new List<TeacherDTO>();

                        foreach (var tea in teachers)
                        {
                            tempRes.Teachers.Add(tea);
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

        public bool UnAssignTeacher(int groupId, int teacherId)
        {
            try
            {
                var deleteMe = _context.GroupTeachers.Where(e => e.GroupId == groupId && e.TeacherId == teacherId).FirstOrDefault();
                if (deleteMe != null)
                {
                    deleteMe.DeactivateDatetime = DateTime.UtcNow;
                    deleteMe.DeactivateUser = "Admin";
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Document> GetAllDocumentsByStudent(int studentId)
        {
            return _context.Documents.Where(e => e.StudentId == studentId).ToList();
        }
    }
}