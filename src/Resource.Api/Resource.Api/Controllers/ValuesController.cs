using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resource.Api.Models;

namespace Resource.Api.Controllers
{
    //[Authorize(Policy = "ApiReader")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        //[Authorize(Policy = "Consumer")]
        [HttpGet]
        [Route("plain")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var dog = "dog";
            using (var context = new Kinder2021Context())
            {
           

                //add students
                for (int i = 1; i < 15; i++)
                {

                    var student = new Student()
                    {
                        CreateDatetime = DateTime.UtcNow,
                        Name = "RandomName_"+i.ToString(),
                        LastName1 = "Lastname1_" + i.ToString(),
                        LastName2 = "Lastname2_" + i.ToString(),
                        Birthday = Convert.ToDateTime("2016-12-"+i.ToString()),
                        CreateUser = "Admin",
                        RegistrationDate = DateTime.UtcNow

                    };
                    context.Students.Add(student);

                }
                context.SaveChanges();
                var students = context.Students.ToList();

            

                return new JsonResult(students.Select(c => new { c.Name, c.LastName1 }));
            }
            //  return new JsonResult(User.Claims.Select(c => new { c.Type, c.Value }));
        }

        //[Authorize(Policy = "Consumer")]
        [Route("test")]

        [HttpGet]
        public ActionResult<IEnumerable<string>> TestDb()
        {
            var dog = "dog";
            using (var context = new Kinder2021Context())
            {


                //add students
                for (int i = 1; i < 15; i++)
                {

                    var student = new Student()
                    {
                        CreateDatetime = DateTime.UtcNow,
                        Name = "RandomName_" + i.ToString(),
                        LastName1 = "Lastname1_" + i.ToString(),
                        LastName2 = "Lastname2_" + i.ToString(),
                        Birthday = Convert.ToDateTime("2016-12-" + i.ToString()),
                        CreateUser = "Admin",
                        RegistrationDate = DateTime.UtcNow

                    };
                    context.Students.Add(student);

                }
                context.SaveChanges();
                var students = context.Students.ToList();



                return new JsonResult(students.Select(c => new { c.Name, c.LastName1 }));
            }
        }


     



    }
}
