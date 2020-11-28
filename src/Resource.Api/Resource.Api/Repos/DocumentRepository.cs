using Resource.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IDocumentRepository
    {
        List<Student> GetAllDocuments();
    }


    public class DocumentRepository : IDocumentRepository
    {
        Kinder2021Context _context;
        public DocumentRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Student> GetAllDocuments()
        {
            return _context.Students.ToList();
        }
    }
}