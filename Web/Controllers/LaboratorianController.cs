using Application.Interface;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Web.Controllers
{
    [Authorize(Policy = "LaboratorianPolicy")]
    public class LaboratorianController : Controller
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

        public IActionResult Index()
        {
            return View();
        }

        // LAB_TEST actions methods
        public IActionResult AddLabTest(int? id)
        {
            if (id.HasValue)
            {
                var labTest = _labTestService.GetLabTestById(id.Value);

                if (labTest != null)
                {
                    return View(labTest);
                }
            }
            return View(new LabTest());
        }

        [HttpPost]
        public IActionResult AddLabTest(LabTest labTest)
        {
            if (ModelState.IsValid)
            {
                if (labTest.Id == 0)
                {
                    _labTestService.AddLabTest(labTest);
                }
                else
                {
                    _labTestService.UpdateLabTest(labTest.Id, labTest);
                }
                return RedirectToAction("ViewLabTest");
            }
            return View(labTest);
        }

        public IActionResult EditLabTest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labTest = _labTestService.GetLabTestById(id.Value);
            if (labTest == null)
            {
                return NotFound();
            }
            return View("AddLabTest", labTest);
        }

        [HttpPost]
        public IActionResult EditLabTest(LabTest labTest)
        {
            if (ModelState.IsValid)
            {
                _labTestService.UpdateLabTest(labTest.Id, labTest);
                return RedirectToAction("ViewLabTest");
            }
            return View("AddLabTest", labTest);
        }

        public IActionResult DeleteLabTest(int id)
        {
            _labTestService.DeleteLabTest(id);
            return RedirectToAction("ViewLabTest");
        }

        public ViewResult ViewLabTest()
        {
            return View(_labTestService.ViewLabTests());
        }

        // LAB_RESULT actions
        public IActionResult UploadLabResult()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadLabResult(LabResult labResult)
        {
            if (ModelState.IsValid)
            {
                byte[] fileContent = null;

                if (labResult.File != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        labResult.File.CopyTo(memoryStream);
                        fileContent = memoryStream.ToArray();
                    }
                }

                _labResultService.UploadLabResult(labResult, fileContent);

                return RedirectToAction("ViewLabResult");
            }
            return View(labResult);
        }

        public IActionResult EditLabResult(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labResult = _labResultService.GetLabResultById(id.Value);
            if (labResult == null)
            {
                return NotFound();
            }
            return View("UploadLabResult", labResult);
        }

        [HttpPost]
        public IActionResult EditLabResult(LabResult labResult)
        {
            if (ModelState.IsValid)
            {
                _labResultService.UpdateLabResult(labResult.Id, labResult);
                return RedirectToAction("ViewLabResult");
            }
            return View("UploadLabResult", labResult);
        }

        public IActionResult DeleteLabResult(int id)
        {
            _labResultService.DeleteLabResult(id);
            return RedirectToAction("ViewLabResult");
        }

        public ViewResult ViewLabResult(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return View(_labResultService.ViewLabResults());
            }
            return View(_labResultService.SearchLabResults(search));
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
