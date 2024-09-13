using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ILabResultRepository : IRepository<LabResult>
    {
        void Upload(LabResult labResult);
        IEnumerable<LabResult> View();
        List<LabResult> Search(string search);
        void Update(int labResultID, LabResult labResult);
        void Delete(int labResultID);
    }
}