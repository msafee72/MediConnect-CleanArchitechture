using Application.Interface;
using Core;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Web.hub;

namespace Web.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    public class AdminController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ILaboratorianService _laboratorianService;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IMemoryCache _memoryCache;
        public AdminController(IDoctorService doctorService, ILaboratorianService laboratorianService, IHubContext<ChatHub> hubContext, IMemoryCache memoryCache)
        {
            _doctorService = doctorService;
            _laboratorianService = laboratorianService;
            _hubContext = hubContext;
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddDoctor(int? id)
        {
            if (id.HasValue)
            {
                var doctor = _doctorService.GetDoctorById(id.Value);

                if (doctor != null)
                {
                    return View(doctor);
                }
            }
            return View(new Doctor());
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            if (doctor.Id == 0)
            {
                _doctorService.AddDoctor(doctor);
            }
            else
            {
                _doctorService.UpdateDoctor(doctor.Id, doctor);
            }


            //await _hubContext.Clients.All.SendAsync("RecieveMessagh", doctor.DoctorName);
            //Console.WriteLine("in");

            await _hubContext.Clients.All.SendAsync("ReceiveMessage");

            return RedirectToAction("ViewDoctor");
        }


        [HttpGet]
        //client-side response cache
        [ResponseCache (Duration = 60, Location = ResponseCacheLocation.Client)]
        public ViewResult ViewDoctor()
        {
            //server-side in-memory cache
            if (!_memoryCache.TryGetValue("doctorCacheKey", out List<Doctor> d))
            {
                d = _doctorService.GetAllDoctors().ToList();


                _memoryCache.Set("doctorCacheKey", d, TimeSpan.FromMinutes(5));

            }

            return View(d);
        }

        public IActionResult EditDoctor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = _doctorService.GetDoctorById(id.Value);

            if (doctor == null)
            {
                return NotFound();
            }

            return View("AddDoctor", doctor);
        }

        [HttpPost]
        public IActionResult EditDoctor(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _doctorService.UpdateDoctor(doctor.Id, doctor);
                return RedirectToAction("ViewDoctor");
            }

            return View("AddDoctor", doctor);
        }

        public IActionResult DeleteDoctor(int id)
        {
            _doctorService.DeleteDoctor(id);

            return RedirectToAction("ViewDoctor");
        }

        public IActionResult AddLaboratorian(int? id)
        {
            if (id.HasValue)
            {
                var laboratorian = _laboratorianService.GetLaboratorianById(id.Value);

                if (laboratorian != null)
                {
                    return View(laboratorian);
                }
            }

            return View(new Laboratorian());
        }

        [HttpPost]
        public IActionResult AddLaboratorian(Laboratorian laboratorian)
        {
            if (laboratorian.Id == 0)
            {
                _laboratorianService.AddLaboratorian(laboratorian);
            }
            else
            {
                _laboratorianService.UpdateLaboratorian(laboratorian.Id, laboratorian);
            }

            return RedirectToAction("ViewLaboratorian");
        }

        public IActionResult ViewLaboratorian()
        {
            return View(_laboratorianService.GetAllLaboratorians());
        }

        public IActionResult EditLaboratorian(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratorian = _laboratorianService.GetLaboratorianById(id.Value);

            if (laboratorian == null)
            {
                return NotFound();
            }

            return View("AddLaboratorian", laboratorian);
        }

        [HttpPost]
        public IActionResult EditLaboratorian(Laboratorian laboratorian)
        {
            if (ModelState.IsValid)
            {
                _laboratorianService.UpdateLaboratorian(laboratorian.Id, laboratorian);
                return RedirectToAction("ViewLaboratorian");
            }

            return View("AddLaboratorian", laboratorian);
        }

        public IActionResult DeleteLaboratorian(int id)
        {
            _laboratorianService.DeleteLaboratorian(id);

            return RedirectToAction("ViewLaboratorian");
        }
    }
}
