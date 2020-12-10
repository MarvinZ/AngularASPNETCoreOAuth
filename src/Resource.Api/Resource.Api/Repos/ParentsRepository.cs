using Resource.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IParentRepository
    {
        List<Parent> GetAllParents();
    }


    public class ParentsRepository : IParentRepository
    {
        Kinder2021Context _context;
        public ParentsRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Parent> GetAllParents()
        {
            return _context.Parents.ToList();
        }


        public bool AddParent(string name, string lastName1, string lastName2, DateTime birthday, char genre, string email, string phone)
        {

            try
            {
                var newParent = new Parent()
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
                _context.Parents.Add(newParent);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool AddParentForStudent(string name, string lastName1, string lastName2, DateTime birthday, char genre, string email, string phone, int studentId)
        {

            try
            {
                var newParent = new Parent()
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
                _context.Parents.Add(newParent);
                _context.SaveChanges();

                var rel = new StudentParent()
                {
                    StudentId = studentId,
                    ParentId = newParent.Id,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "ADMIN"
                };

                _context.StudentParents.Add(rel);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public ParentDTO GetParentDetails(int parentId)
        {
            try
            {
                var result = new StudentDTO();
                var tempRes = _context.Parents.Where(e => e.Id == parentId).Select(student => new ParentDTO
                {
                    Id = student.Id,
                    Birthday = student.Birthday,
                    RegistrationDate = student.RegistrationDate,
                    Name = student.Name,
                    Lastnames = student.LastName1 + " " + student.LastName2,
                }).FirstOrDefault();

                if (tempRes != null)
                {
                    var parents = _context.Parents.Join(_context.StudentParents.Where(e => e.StudentId == parentId),
                        parent => parent.Id,
                        studentParent => studentParent.ParentId,
                        (parent, studentParent) => new ParentDTO
                        {
                            Name = parent.Name,
                            Lastnames = parent.LastName1 + " " + parent.LastName2,
                        }).ToList();

                    //if (parents != null)
                    //{
                    //    tempRes.Parents = new List<ParentDTO>();

                    //    foreach (var par in parents)
                    //    {
                    //        tempRes.Parents.Add(par);
                    //    }
                    //}

                    var groups = _context.Groups.Join(_context.GroupStudents.Where(e => e.StudentId == parentId),
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

                    //if (groups != null)
                    //{
                    //    tempRes.Groups = new List<GroupDTO>();

                    //    foreach (var g in groups)
                    //    {
                    //        tempRes.Groups.Add(g);
                    //    }
                    //}

                }
                return tempRes;

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}