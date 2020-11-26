using Resource.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IParentRepository
    {
        List<Parent> GetAllParents();
    }


    public class ParentRepository : IParentRepository
    {
        Kinder2021Context _context;
        public ParentRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Parent> GetAllParents()
        {
            return _context.Parents.ToList();
        }
    }
}