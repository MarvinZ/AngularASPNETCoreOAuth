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

        public bool CreateDocument(int clientId, bool isProfilePic, int? studentId, int? teacherId, int? groupId, int? paymentRequestId, string dbPath, string title)
        {
            try
            {
                var newDoc = new Document()
                {
                    IsProfilePic = isProfilePic,
                    ClientId = clientId,
                    FileLocation = dbPath,
                    GroupId = groupId == 0 ? null : groupId,
                    StudentId = studentId == 0 ? null : studentId,
                    TeacherId = teacherId == 0 ? null : teacherId,
                    Title = title,
                    PaymentRequestId = paymentRequestId,
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