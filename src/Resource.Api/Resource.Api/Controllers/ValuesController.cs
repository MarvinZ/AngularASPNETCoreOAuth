using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resource.Api.Models;

namespace Resource.Api.Controllers
{
    [Authorize(Policy = "ApiReader")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [Authorize(Policy = "Consumer")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
          var dog = "dog";
            using (var context = new Kinder2021Context())
            {
                var students = context.Students.ToList();
                return new JsonResult(students.Select(c => new { c.Name, c.LastName1 }));
            }
          //  return new JsonResult(User.Claims.Select(c => new { c.Type, c.Value }));
        }

        //[Authorize(Policy = "Consumer")]
        //[HttpGet]
        public ActionResult<IEnumerable<string>> TestDb()
        {
            using (var context = new Kinder2021Context())
            {
                var students = context.Students.ToList();
                return new JsonResult(students.Select(c => new { c.Name, c.LastName1 }));
            }


        }
    }
}
