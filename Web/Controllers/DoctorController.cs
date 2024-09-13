using Application.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize(Policy = "DoctorPolicy")]
    public class DoctorController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly ILabResultService _labResultService;
        private readonly IWebHostEnvironment _env;

        public DoctorController(IPatientService patientService, IPrescriptionService prescriptionService, ILabResultService labResultService, IWebHostEnvironment env)
        {
            _patientService = patientService;
            _prescriptionService = prescriptionService;
            _labResultService = labResultService;
            _env = env;
            

        }

        public IActionResult Index()
        {
            return View();
        }

        //*****************PATIENT*****************
        public IActionResult AddPatient(int? id)
        {
            var patient = id.HasValue ? _patientService.GetPatientById(id.Value) : new Patient();
            return View(patient);
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            if (patient.Id == 0)
            {
                _patientService.AddPatient(patient);
            }
            else
            {
                _patientService.UpdatePatient(patient.Id, patient);
            }
            return RedirectToAction("ViewPatient", "Doctor");
        }

        public IActionResult ViewPatient()
        {
            var patients = _patientService.GetAllPatients();
            return View(patients);
        }

        public IActionResult EditPatient(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var patient = _patientService.GetPatientById(id.Value);
            if (patient == null)
            {
                return NotFound();
            }

            return View("AddPatient", patient);
        }

        [HttpPost]
        public IActionResult EditPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.UpdatePatient(patient.Id, patient);
                return RedirectToAction("ViewPatient");
            }

            return View("AddPatient", patient);
        }

        public IActionResult DeletePatient(int id)
        {
            _patientService.DeletePatient(id);
            return RedirectToAction("ViewPatient");
        }

        //*****************PRESCRIPTION*****************
        public IActionResult AddPrescription(int? id)
        {
            var prescription = id.HasValue ? _prescriptionService.GetPrescriptionById(id.Value) : new Prescription();
            return View(prescription);
        }

        [HttpPost]
        public IActionResult AddPrescription(Prescription prescription)
        {
            if (prescription.Id == 0)
            {
                _prescriptionService.AddPrescription(prescription);
            }
            else
            {
                _prescriptionService.UpdatePrescription(prescription.Id, prescription);
            }
            return RedirectToAction("ViewPrescription", "Doctor");
        }

        public IActionResult ViewPrescription()
        {
            var prescriptions = _prescriptionService.GetAllPrescriptions();
            return View(prescriptions);
        }

        public IActionResult EditPrescription(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var prescription = _prescriptionService.GetPrescriptionById(id.Value);
            if (prescription == null)
            {
                return NotFound();
            }

            return View("AddPrescription", prescription);
        }

        [HttpPost]
        public IActionResult EditPrescription(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _prescriptionService.UpdatePrescription(prescription.Id, prescription);
                return RedirectToAction("ViewPrescription");
            }

            return View("AddPrescription", prescription);
        }

        public IActionResult DeletePrescription(int id)
        {
            _prescriptionService.DeletePrescription(id);
            return RedirectToAction("ViewPrescription");
        }


        //*****************SEARCH LAB TEST RESULT*****************
        public ViewResult ViewLabTest(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                var labResults = _labResultService.ViewLabResults();
                return View(labResults);
            }
            else
            {
                var labResults = _labResultService.SearchLabResults(search);
                return View(labResults);
            }
        }





    }
}

