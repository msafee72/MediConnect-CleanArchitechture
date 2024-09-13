using Application.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaboratorianController : ControllerBase
    {
        private readonly ILabTestService _labTestService;
        private readonly ILabResultService _labResultService;
        private readonly IWebHostEnvironment _env;

        public LaboratorianController(ILabTestService labTestService, ILabResultService labResultService, IWebHostEnvironment env)
        {
            _labTestService = labTestService;
            _labResultService = labResultService;
            _env = env;
        }

        // LAB_TEST actions

        [HttpGet("GetLabTest/{id}")]
        public ActionResult<LabTest> GetLabTest(int id)
        {
            var labTest = _labTestService.GetLabTestById(id);

            if (labTest == null)
            {
                return NotFound();
            }
            return Ok(labTest);
        }

        [HttpPost("AddLabTest")]
        public ActionResult AddLabTest([FromBody] LabTest labTest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (labTest.Id == 0)
            {
                _labTestService.AddLabTest(labTest);
            }
            else
            {
                _labTestService.UpdateLabTest(labTest.Id, labTest);
            }

            return Ok();
        }

        [HttpDelete("DeleteLabTest/{id}")]
        public IActionResult DeleteLabTest(int id)
        {
            _labTestService.DeleteLabTest(id);
            return Ok();
        }

        [HttpGet("ViewLabTests")]
        public ActionResult<IEnumerable<LabTest>> ViewLabTests()
        {
            return Ok(_labTestService.ViewLabTests());
        }

        // LAB_RESULT actions

        [HttpPost("UploadLabResult")]
        public async Task<IActionResult> UploadLabResult([FromForm] LabResult labResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            byte[] fileContent = null;

            if (labResult.File != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await labResult.File.CopyToAsync(memoryStream);
                    fileContent = memoryStream.ToArray();
                }
            }

            _labResultService.UploadLabResult(labResult, fileContent);

            return Ok();
        }

        [HttpDelete("DeleteLabResult/{id}")]
        public IActionResult DeleteLabResult(int id)
        {
            _labResultService.DeleteLabResult(id);
            return Ok();
        }

        [HttpGet("ViewLabResults")]
        public ActionResult<IEnumerable<LabResult>> ViewLabResults([FromQuery] string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return Ok(_labResultService.ViewLabResults());
            }
            return Ok(_labResultService.SearchLabResults(search));
        }

        private string SaveImage(IFormFile image)
        {
            string imageFolder = Path.Combine(_env.WebRootPath, "uploads");

            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            if (image == null)
            {
                return Path.Combine("uploads", "default_image.png");
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "-" + image.FileName;
            string filePath = Path.Combine(imageFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return Path.Combine("uploads", uniqueFileName);
        }
    }
}
