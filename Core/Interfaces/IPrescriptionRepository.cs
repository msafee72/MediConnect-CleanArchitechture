using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        //public void Add(Prescription prescription);

        public IEnumerable<Prescription> View();

        public void Update(int Id, Prescription prescription);

        //public void Delete(int prescriptionId);


    }

}
