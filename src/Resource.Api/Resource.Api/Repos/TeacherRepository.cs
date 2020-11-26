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


    public class TeacherRepository : ITeacherRepository
    {
        Kinder2021Context _context;
        public TeacherRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        public bool CreateTeacher(NewPersonDTO request)
        {
            try
            {
                var newRecord = new Teacher()
                {
                    CreateDatetime = System.DateTime.UtcNow,
                    Name = request.Name,
                    LastName1 = request.LastName1,
                    LastName2 = request.LastName1,
                    Birthday = Convert.ToDateTime("2018-12-1"),
                    CreateUser = "Admin",
                    RegistrationDate = DateTime.UtcNow

                };
                _context.Teachers.Add(newRecord);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }



}