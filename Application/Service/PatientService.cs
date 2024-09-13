using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Core;
using Core.Entities;
using Core.Interfaces;

namespace Application.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.View();
        }

        public Patient GetPatientById(int id)
        {
            return _patientRepository.View().FirstOrDefault(p => p.Id == id);
        }

        public void AddPatient(Patient patient)
        {
            _patientRepository.Add(patient);
        }

        public void UpdatePatient(int id, Patient patient)
        {
            _patientRepository.Update(id, patient);
        }

        public void DeletePatient(int id)
        {
            _patientRepository.Delete(id);
        }
    }
}

