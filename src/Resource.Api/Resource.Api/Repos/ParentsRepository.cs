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

        public bool AddParentForStudent(int clientid, string name, string lastName1, string lastName2, DateTime birthday, char genre, string email, string phone, int studentId, string cedula)
        {

            try
            {
                var newParent = new Parent()
                {
                    ClientId = clientid,
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
                    CountryId = cedula
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
                    var kids = _context.Students.Join(_context.StudentParents.Where(e => e.ParentId == parentId),
                        student => student.Id,
                        studentParent => studentParent.StudentId,
                        (student, studentParent) => new StudentDTO
                        {
                            Id = student.Id,
                            Name = student.Name + " " + student.LastName1 + " " + student.LastName2,
                        }).ToList();

                    if (kids != null)
                    {
                        tempRes.Kids = new List<StudentDTO>();

                        foreach (var par in kids)
                        {
                            tempRes.Kids.Add(par);
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

        internal NameDTO GetNameFromCedula(int cedula)
        {
            var res = _context.PadronCompletos.Where(e => e.Cedula == cedula).Select(e =>
           new NameDTO()
           {
               Cedula = e.Cedula,
               LastName1 = e.Apellido1,
               LastName2 = e.Apellido2,
               Name = e.Nombre
           }).FirstOrDefault();

            return res;
        }

        internal NameDTO GetExistingNameFromCedula(int cedula)
        {
            var res = _context.Parents.Where(e => e.CountryId == cedula.ToString()).Select(e =>
           new NameDTO()
           {
               Id = e.Id,
               Cedula = int.Parse(e.CountryId),
               LastName1 = e.LastName1,
               LastName2 = e.LastName2,
               Name = e.Name
           }).FirstOrDefault();

            return res;
        }






    }
}