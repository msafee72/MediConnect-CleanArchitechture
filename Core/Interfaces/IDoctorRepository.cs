using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        //public void Add(Doctor doctor);
        public IEnumerable<Doctor> View();
        public void Update(int doctorID, Doctor doctor);

        //public void Delete(int doctorID);

    }
}
