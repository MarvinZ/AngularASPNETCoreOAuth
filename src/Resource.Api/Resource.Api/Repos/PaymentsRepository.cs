using Resource.Api.Enums;
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
        internal bool CreateStudentPaymentRequest(int clientId, int PaymentRequestTypeId, int studentId, decimal amount, string details, string duedate)
        {
            try
            {
                var newPaymentRequest = new PaymentRequest()
                {
                    ClientId = clientId,
                    Amount = amount,
                    StudentId = studentId,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "admin",
                    PaymentTypeId = PaymentRequestTypeId,
                    DueDate = DateTime.Parse(duedate),
                    PaymentStatusId = 1

                };
                _context.PaymentRequests.Add(newPaymentRequest);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        internal bool CreateGroupPaymentRequest(int clientId, int groupId, decimal amount, string dueDate, int paymentType)
        {
            try
            {

                var students = _context.GroupStudents.Where(e => e.GroupId == groupId).ToList();

                foreach (var item in students)
                {
                    var newPaymentRequest = new PaymentRequest()
                    {
                        Amount = amount,
                        StudentId = item.StudentId,
                        CreateDatetime = DateTime.UtcNow,
                        CreateUser = "admin",
                        PaymentTypeId = paymentType,
                        DueDate = DateTime.Parse(dueDate),
                        ClientId = clientId,
                        PaymentStatusId = 1,


                    };
                    _context.PaymentRequests.Add(newPaymentRequest);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
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
                    PaidTime = e.Payments.FirstOrDefault() == null ? new DateTime(1900, 1, 1) : e.Payments.FirstOrDefault().CreateDatetime,
                    PaidBy = e.Payments.FirstOrDefault() == null ? "" : e.Payments.FirstOrDefault().Parent.Name + " " + e.Payments.FirstOrDefault().Parent.LastName1,
                    PaymentRequestTypeName = e.PaymentType.Name,
                    PaymentStatusName = e.PaymentStatus.Name,
                    DueDate = e.DueDate,
                    Details = "NEED CODE FIX"
                }).ToList();

            return result;
        }

        internal List<FinancialDTO> GetAllFinancialsForParent(int parentId)
        {
            var students = _context.StudentParents.Where(e => e.ParentId == parentId).ToList();
            var tempStudents = new List<int>();
            foreach (var item in students)
            {
                tempStudents.Add(item.StudentId);
            }
            var result = _context.PaymentRequests.Where(e => tempStudents.Contains(e.StudentId) && e.DeactivateDatetime == null)
                .Select(e => new FinancialDTO()
                {
                    Id = e.Id,
                    RequestedAmount = e.Amount,
                    PaidAmount = e.Payments.FirstOrDefault() == null ? 0 : e.Payments.FirstOrDefault().Amount,
                    RequestedTime = e.CreateDatetime,
                    PaidTime = e.Payments.FirstOrDefault() == null ? new DateTime(1900, 1, 1) : e.Payments.FirstOrDefault().CreateDatetime,
                    PaidBy = e.Payments.FirstOrDefault() == null ? "" : e.Payments.FirstOrDefault().Parent.Name + " " + e.Payments.FirstOrDefault().Parent.LastName1,
                    PaymentRequestTypeName = e.PaymentType.Name,
                    PaymentStatusName = e.PaymentStatus.Name,
                    DueDate = e.DueDate,
                    Details = e.PaymentType.Name,
                    StudentName = e.Student.Name + " " + e.Student.LastName1,


                }).ToList();

            return result;
        }




        internal bool Pay(int clientId, int parentId, int PaymentRequestId)
        {
            try
            {
                var originalPaymentRequest = _context.PaymentRequests.Where(e => e.Id == PaymentRequestId).FirstOrDefault();
                var newPayment = new Payment()
                {
                    PaymentRequestId = PaymentRequestId,
                    Amount = originalPaymentRequest.Amount,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "admin",
                    ParentId = parentId

                };
                _context.Payments.Add(newPayment);
                originalPaymentRequest.PaymentStatusId = (int)PaymentStatusEnum.InReview;
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