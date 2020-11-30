using Resource.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resource.Api
{

    public interface IPaymentRepository
    {
        public List<PaymentDTO> GetNewPayments();
        public bool CreatePayment(int parentId, decimal amount);


    }


    public class PaymentsRepository : IPaymentRepository
    {
        Kinder2021Context _context;
        public PaymentsRepository(Kinder2021Context context)
        {
            _context = context;
        }
        public List<PaymentDTO> GetNewPayments()
        {
            var result = _context.Payments.Select(c => new PaymentDTO
            {
                Amount = c.Amount,
                StudentName = "NECESITAS ARREGLAR ALGO AQUI",
                CreateUser = c.CreateUser,
                CreateDatetime = c.CreateDatetime,

                Id = c.Id
            }).ToList();

            return result;
        }

        public bool CreatePayment(int parentId, decimal amount)
        {
            try
            {
                var newPayment = new Payment()
                {
                    Amount = amount,
                    ParentId = parentId,
                    CreateDatetime = DateTime.UtcNow,
                    CreateUser = "admin",

                };
                _context.Payments.Add(newPayment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;            }
        }




    }
}