using Application.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IPrescriptionService _prescriptionService;
        private readonly ILabResultService _labResultService;

        public DoctorController(IPatientService patientService, IPrescriptionService prescriptionService, ILabResultService labResultService)
        {
            _patientService = patientService;
            _prescriptionService = prescriptionService;
            _labResultService = labResultService;
        }

        //*****************PATIENT*****************

        [HttpGet("patients/{id}")]
        public ActionResult<Patient> GetPatient(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        [HttpPost("patients")]
        public IActionResult AddPatient(Patient patient)
        {
            if (patient.Id == 0)
            {
                _patientService.AddPatient(patient);
                return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
            }
            else
            {
                _patientService.UpdatePatient(patient.Id, patient);
                return NoContent();
            }
        }

        [HttpGet("patients")]
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            var patients = _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpDelete("patients/{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();

            _patientService.DeletePatient(id);
            return NoContent();
        }

        //*****************PRESCRIPTION*****************

        [HttpGet("prescriptions/{id}")]
        public ActionResult<Prescription> GetPrescription(int id)
        {
            var prescription = _prescriptionService.GetPrescriptionById(id);
            if (prescription == null)
                return NotFound();
            return Ok(prescription);
        }

        [HttpPost("prescriptions")]
        public IActionResult AddPrescription(Prescription prescription)
        {
            if (prescription.Id == 0)
            {
                _prescriptionService.AddPrescription(prescription);
                return CreatedAtAction(nameof(GetPrescription), new { id = prescription.Id }, prescription);
            }
            else
            {
                _prescriptionService.UpdatePrescription(prescription.Id, prescription);
                return NoContent();
            }
        }

        [HttpGet("prescriptions")]
        public ActionResult<IEnumerable<Prescription>> GetAllPrescriptions()
        {
            var prescriptions = _prescriptionService.GetAllPrescriptions();
            return Ok(prescriptions);
        }

        [HttpDelete("prescriptions/{id}")]
        public IActionResult DeletePrescription(int id)
        {
            var prescription = _prescriptionService.GetPrescriptionById(id);
            if (prescription == null)
                return NotFound();

            _prescriptionService.DeletePrescription(id);
            return NoContent();
        }

        //*****************SEARCH LAB TEST RESULT*****************

        [HttpGet("labresults")]
        public ActionResult<IEnumerable<LabResult>> ViewLabTest([FromQuery] string search)
        {
            var labResults = string.IsNullOrEmpty(search)
                ? _labResultService.ViewLabResults()
                : _labResultService.SearchLabResults(search);

            return Ok(labResults);
        }
    }
}


