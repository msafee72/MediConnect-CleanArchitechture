using Application.Interface;
using Core.Interfaces;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Doctor GetDoctorById(int id)
        {
            return _doctorRepository.View().FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _doctorRepository.View();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            _doctorRepository.Add(doctor);
        }

        public void UpdateDoctor(int id, Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));

            _doctorRepository.Update(id, doctor);
        }

        public void DeleteDoctor(int id)
        {
            _doctorRepository.Delete(id);
        }

    }

}
