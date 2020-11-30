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


    public class GroupRepository : IGroupRepository
    {
        Kinder2021Context _context;
        public GroupRepository(Kinder2021Context context)
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