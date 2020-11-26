using Resource.Api.Models;
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
    }
}