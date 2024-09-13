using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IDoctorService
    {
        Doctor GetDoctorById(int id);
        IEnumerable<Doctor> GetAllDoctors();
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(int id, Doctor doctor);
        void DeleteDoctor(int id);

    }
}
