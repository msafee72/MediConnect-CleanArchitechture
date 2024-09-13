using Application.Interface;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly ILaboratorianService _laboratorianService;
        private readonly IMemoryCache _memoryCache;

        public AdminController(IDoctorService doctorService, ILaboratorianService laboratorianService, IMemoryCache memoryCache)
        {
            _doctorService = doctorService;
            _laboratorianService = laboratorianService;
            _memoryCache = memoryCache;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Admin API is working.");
        }

        // ************ DOCTOR ************
        [HttpGet("AddDoctor/{id?}")]
        public ActionResult<Doctor> AddDoctor(int? id)
        {
            if (id.HasValue)
            {
                var doctor = _doctorService.GetDoctorById(id.Value);
                if (doctor != null)
                {
                    return Ok(doctor);
                }
                return NotFound();
            }
            return Ok(new Doctor());
        }

        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            if (doctor.Id == 0)
            {
                _doctorService.AddDoctor(doctor);
            }
            else
            {
                _doctorService.UpdateDoctor(doctor.Id, doctor);
            }

            return Ok();
        }

        [HttpGet("ViewDoctor")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public ActionResult<IEnumerable<Doctor>> ViewDoctor()
        {
            if (!_memoryCache.TryGetValue("doctorCacheKey", out List<Doctor> doctors))
            {
                doctors = _doctorService.GetAllDoctors().ToList();
                _memoryCache.Set("doctorCacheKey", doctors, TimeSpan.FromMinutes(5));
            }

            return Ok(doctors);
        }

        [HttpPost("EditDoctor")]
        public IActionResult EditDoctor([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _doctorService.UpdateDoctor(doctor.Id, doctor);
            return Ok();
        }

        [HttpDelete("DeleteDoctor/{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            _doctorService.DeleteDoctor(id);
            return Ok();
        }

        // ************ LABORATORIAN ************
        [HttpGet("AddLaboratorian/{id?}")]
        public ActionResult<Laboratorian> AddLaboratorian(int? id)
        {
            if (id.HasValue)
            {
                var laboratorian = _laboratorianService.GetLaboratorianById(id.Value);
                if (laboratorian != null)
                {
                    return Ok(laboratorian);
                }
                return NotFound();
            }
            return Ok(new Laboratorian());
        }

        [HttpPost("AddLaboratorian")]
        public IActionResult AddLaboratorian([FromBody] Laboratorian laboratorian)
        {
            if (laboratorian.Id == 0)
            {
                _laboratorianService.AddLaboratorian(laboratorian);
            }
            else
            {
                _laboratorianService.UpdateLaboratorian(laboratorian.Id, laboratorian);
            }

            return Ok();
        }

        [HttpGet("ViewLaboratorian")]
        public ActionResult<IEnumerable<Laboratorian>> ViewLaboratorian()
        {
            return Ok(_laboratorianService.GetAllLaboratorians());
        }

        [HttpPost("EditLaboratorian")]
        public IActionResult EditLaboratorian([FromBody] Laboratorian laboratorian)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _laboratorianService.UpdateLaboratorian(laboratorian.Id, laboratorian);
            return Ok();
        }

        [HttpDelete("DeleteLaboratorian/{id}")]
        public IActionResult DeleteLaboratorian(int id)
        {
            _laboratorianService.DeleteLaboratorian(id);
            return Ok();
        }
    }
}
