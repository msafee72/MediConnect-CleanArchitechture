using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        //public void Add(Patient patient);

        public IEnumerable<Patient> View();

        public void Update(int patientId, Patient patient);

        //public void Delete(int patientId);
    }

}
