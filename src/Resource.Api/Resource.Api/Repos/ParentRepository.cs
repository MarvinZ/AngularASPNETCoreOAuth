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
   

    public bool CreateParent(NewPersonDTO request)
    {
        try
        {
            var newRecord = new Parent()
            {
                CreateDatetime = DateTime.UtcNow,
                Name = request.Name,
                LastName1 = request.LastName1,
                LastName2 = request.LastName1,
                Birthday = Convert.ToDateTime("2018-12-1"),
                CreateUser = "Admin",
                RegistrationDate = DateTime.UtcNow

            };
            _context.Parents.Add(newRecord);
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