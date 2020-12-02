using Resource.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IDocumentRepository
    {
        List<Student> GetAllDocuments();
    }


    public class DocumentsRepository : IDocumentRepository
    {
        Kinder2021Context _context;
        public DocumentsRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<Student> GetAllDocuments()
        {
            return _context.Students.ToList();
        }

        public bool CreateDocument(int? studentId, int? groupId, string dbPath, string title)
        {
            try
            {
                var newDoc = new Document()
                {
                    FileLocation = dbPath,
                    GroupId = groupId == 0 ? null : groupId,
                    StudentId = studentId == 0 ? null : studentId,
                    Title = title,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "admin",

                };
                _context.Documents.Add(newDoc);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }




    }
}