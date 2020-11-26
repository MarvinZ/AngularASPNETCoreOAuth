using Resource.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
    }


    public class StudentRepository : IStudentRepository
    {
        Kinder2021Context _context;
        public StudentRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }
    }
}