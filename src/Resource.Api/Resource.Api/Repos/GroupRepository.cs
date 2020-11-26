using Resource.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IGroupRepository
    {
        List<Group> GetAllGroups();
    }


    public class GroupRepository : IGroupRepository
    {
        Kinder2021Context _context;
        public GroupRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Group> GetAllGroups()
        {
            return _context.Groups.ToList();
        }
    }
}