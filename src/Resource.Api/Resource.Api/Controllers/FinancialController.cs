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
        public List<PaymentDTO> GetNewPayments()
        {
            return _PaymentsRepo.GetNewPayments();
        }

        [HttpPost]
        [Route("CreatePayment")]
        public bool CreatePayment(NewPaymentDTO request)
        {
            return _PaymentsRepo.CreatePayment(request.ParentId, request.Amount);
        }


    }
}
