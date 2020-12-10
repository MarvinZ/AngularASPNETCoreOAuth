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
            var result = _context.Groups.Select(c => new GroupDTO
            {
                CycleName = c.Cycle.Name,
                AmountOfStudents = 99,
                CreateUser = c.CreateUser,
                CreateDatetime = c.CreateDatetime,
                LevelName = c.Level.Name,
                GroupShortname = c.GroupShortname,
                Id = c.Id
            }).ToList();

            return result;
        }

        public bool CreateGroup(int levelId, int cycleId, string shortName)
        {
            try
            {
                var newGroup = new Group()
                {
                    LevelId = levelId,
                    CycleId = cycleId,
                    GroupShortname = shortName,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "ADMIN"
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
                var result = _context.Groups.Select(c => new GroupDTO
                {
                    CycleName = c.Cycle.Name,
                    AmountOfStudents = 99,
                    CreateUser = c.CreateUser,
                    CreateDatetime = c.CreateDatetime,
                    LevelName = c.Level.Name,
                    GroupShortname = c.GroupShortname,
                    Id = c.Id
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
                Levels = _context.Levels.Where(e => e.DeactivateDatetime == null).ToList()

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
                    LevelName = group.Level.Name





                }).FirstOrDefault();

                //if (tempRes != null)
                //{
                //    var parents = _context.Parents.Join(_context.StudentParents.Where(e => e.StudentId == studentId),
                //        parent => parent.Id,
                //        studentParent => studentParent.ParentId,
                //        (parent, studentParent) => new ParentDTO
                //        {
                //            Name = parent.Name,
                //            Lastnames = parent.LastName1 + " " + parent.LastName2,
                //        }).ToList();

                //    if (parents != null)
                //    {
                //        tempRes.Parents = new List<ParentDTO>();

                //        foreach (var par in parents)
                //        {
                //            tempRes.Parents.Add(par);
                //        }
                //    }
                //}
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