using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ILabTestRepository : IRepository<LabTest>
    {
        //public void Add(LabTest l);

        public IEnumerable<LabTest> View();

        public void Update(int id, LabTest l);

        //public void Delete(int id);
    }

}
