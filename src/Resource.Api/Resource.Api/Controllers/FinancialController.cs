using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Resource.Api.Models;

namespace Resource.Api.Controllers
{
    //[Authorize(Policy = "ApiReader")]
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        DocumentsRepository _DocumentsRepo;
        PaymentsRepository _PaymentsRepo;

        public FinancialController(PaymentsRepository PaymentsRepo, DocumentsRepository DocumentsRepo)
        {
            _PaymentsRepo = PaymentsRepo;
            _DocumentsRepo = DocumentsRepo;
        }

        [HttpPost]
        [Route("GetNewPayments")]
        public List<FinancialDTO> GetNewPayments()
        {
            return _PaymentsRepo.GetNewPayments();
        }

        [HttpPost]
        [Route("CreatePayment")]
        public bool CreatePayment(PaymentsDTO request)
        {
            return _PaymentsRepo.CreatePayment(request.PaymentRequestId, request.ParentId, request.Amount);
        }


        [HttpPost]
        [Route("CreateStudentPaymentRequest")]
        public bool CreateStudentPaymentRequest(PaymentsDTO request)
        {
            return _PaymentsRepo.CreateStudentPaymentRequest(request.ClientId, request.PaymentRequestTypeId, request.StudentId, request.Amount, request.Details, request.DueDate);
        }

        [HttpPost]
        [Route("CreateGroupPaymentRequest")]
        public bool CreateGroupPaymentRequest(PaymentsDTO request)
        {
            return _PaymentsRepo.CreateGroupPaymentRequest(request.GroupId, request.Amount, request.DueDate, request.PaymentRequestTypeId);
        }


        [HttpPost]
        [Route("GetAllFinancialsForStudent")]
        public List<FinancialDTO> GetAllFinancialsForStudent(PaymentsDTO request)
        {
            return _PaymentsRepo.GetAllFinancialsForStudent(request.StudentId);
        }


        [HttpPost]
        [Route("GetAllFinancialsForParent")]
        public List<FinancialDTO> GetAllFinancialsForParent(PaymentsDTO request)
        {
            return _PaymentsRepo.GetAllFinancialsForParent(request.StudentId);
        }


    }
}
