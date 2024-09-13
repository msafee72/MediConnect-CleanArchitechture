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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return _prescriptionRepository.View();
        }

        public Prescription GetPrescriptionById(int id)
        {
            return _prescriptionRepository.View().FirstOrDefault(p => p.Id == id);
        }

        public void AddPrescription(Prescription prescription)
        {
            _prescriptionRepository.Add(prescription);
        }

        public void UpdatePrescription(int id, Prescription prescription)
        {
            _prescriptionRepository.Update(id, prescription);
        }

        public void DeletePrescription(int id)
        {
            _prescriptionRepository.Delete(id);
        }
    }
}
