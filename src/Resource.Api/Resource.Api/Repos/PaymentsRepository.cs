using Resource.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IPaymentRepository
    {
        public List<FinancialDTO> GetNewPayments();
        public bool CreatePayment(int requestId, int parentId, decimal amount);

    }


    public class PaymentsRepository : IPaymentRepository
    {
        Kinder2021Context _context;
        public PaymentsRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<FinancialDTO> GetNewPayments()
        {
            var result = _context.Payments.Select(c => new FinancialDTO
            {
                RequestedAmount = c.Amount,
                StudentName = "NECESITAS ARREGLAR ALGO AQUI",
                CreateUser = c.CreateUser,
                CreateDatetime = c.CreateDatetime,

                Id = c.Id
            }).ToList();

            return result;
        }

        public bool CreatePayment(int requestId, int parentId, decimal amount)
        {
            try
            {
                var newPayment = new Payment()
                {
                    Amount = amount,
                    ParentId = parentId,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "admin",
                    PaymentRequestId = requestId
                };
                _context.Payments.Add(newPayment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal bool CreateStudentPaymentRequest(int studentId, decimal amount, DateTime dueDate, int paymentType)
        {
            try
            {
                var newPaymentRequest = new PaymentRequest()
                {
                    Amount = amount,
                    StudentId = studentId,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "admin",
                    PaymentTypeId = paymentType,
                    DueDate = dueDate

                };
                _context.PaymentRequests.Add(newPaymentRequest);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal bool CreateGroupPaymentRequest(int groupId, decimal amount, DateTime dueDate, int paymentType)
        {
            try
            {

                var students = _context.GroupStudents.Where(e => e.GroupId == groupId).Select(e => new int()).ToList();

                foreach (var item in students)
                {
                    var newPaymentRequest = new PaymentRequest()
                    {
                        Amount = amount,
                        StudentId = item,
                        CreateDatetime = DateTime.UtcNow,
                        CreateUser = "admin",
                        PaymentTypeId = paymentType,
                        DueDate = dueDate

                    };
                    _context.PaymentRequests.Add(newPaymentRequest);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        internal List<FinancialDTO> GetAllFinancialsForStudent(int studentId)
        {
            var result = _context.PaymentRequests.Where(e => e.StudentId == studentId && e.DeactivateDatetime == null)
                .Select(e => new FinancialDTO()
                {
                    Id = e.Id,
                    RequestedAmount = e.Amount,
                    PaidAmount = e.Payments.FirstOrDefault() == null ? 0 : e.Payments.FirstOrDefault().Amount,
                    RequestedTime = e.CreateDatetime,
                    PaidTime = e.Payments.FirstOrDefault() != null ? e.Payments.FirstOrDefault().CreateDatetime : new DateTime(),
                    PaidBy = e.Payments.FirstOrDefault() == null ? "" : e.Payments.FirstOrDefault().Parent.Name + " " + e.Payments.FirstOrDefault().Parent.LastName1,
                    PaymentRequestTypeName = e.PaymentType.Name,
                    PaymentStatusName = e.PaymentStatus.Name

                }).ToList();

            return result;
        }

        internal List<FinancialDTO> GetAllFinancialsForParent(int parentId)
        {
            var students = _context.StudentParents.Where(e => e.ParentId == parentId).Select(e => new int()).ToList();
            var result = _context.PaymentRequests.Where(e=> students.Contains(e.StudentId) && e.DeactivateDatetime == null)
                .Select(e => new FinancialDTO()
                {
                    Id = e.Id,
                    RequestedAmount = e.Amount,
                    PaidAmount = e.Payments.FirstOrDefault() == null ? 0 : e.Payments.FirstOrDefault().Amount,
                    RequestedTime = e.CreateDatetime,
                    PaidTime = e.Payments.FirstOrDefault() != null ? e.Payments.FirstOrDefault().CreateDatetime : new DateTime(),
                    PaidBy = e.Payments.FirstOrDefault() == null ? "" : e.Payments.FirstOrDefault().Parent.Name + " " + e.Payments.FirstOrDefault().Parent.LastName1,
                    PaymentRequestTypeName = e.PaymentType.Name,
                    PaymentStatusName = e.PaymentStatus.Name,
                    StudentName = e.Student.Name + " " + e.Student.LastName1                    

                }).ToList();

            return result;
        }

        
    }
}