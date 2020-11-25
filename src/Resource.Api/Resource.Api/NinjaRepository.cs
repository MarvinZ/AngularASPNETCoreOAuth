using Resource.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface INinjaRepository
    {
        List<Student> GetAllNinjas();
    }


    public class NinjaRepository : INinjaRepository
    {
        Kinder2021Context _context;
        public NinjaRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Student> GetAllNinjas()
        {
            return _context.Students.ToList();
        }
    }
}