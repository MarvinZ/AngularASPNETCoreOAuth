using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace Resource.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        DocumentsRepository _DocumentsRepo;

        public UploadController(DocumentsRepository DocumentsRepo)
        {
            _DocumentsRepo = DocumentsRepo;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var dict = Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());
                var studentId = int.Parse(dict["StudentId"]);
                var groupId = int.Parse(dict["GroupId"]);
                var clientId = int.Parse(dict["ClientId"]);
                var isProfilePic = bool.Parse(dict["IsProfilePic"]);

                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    var success = false;
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    success = _DocumentsRepo.CreateDocument(clientId, isProfilePic,  studentId, groupId, dbPath, fileName);

                    if (success)
                    {
                        return Ok(new { dbPath });
                    }
                    return BadRequest();

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


    }
}
