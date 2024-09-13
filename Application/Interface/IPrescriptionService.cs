using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPrescriptionService
    {
        IEnumerable<Prescription> GetAllPrescriptions();
        Prescription GetPrescriptionById(int id);
        void AddPrescription(Prescription prescription);
        void UpdatePrescription(int id, Prescription prescription);
        void DeletePrescription(int id);
    }
}

