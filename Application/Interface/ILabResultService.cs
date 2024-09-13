using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interface
{
    public interface ILabResultService
    {
        IEnumerable<LabResult> ViewLabResults();
        LabResult GetLabResultById(int id);
        void UploadLabResult(LabResult labResult, byte[] fileContent); // Ensure this matches the service method
        void UpdateLabResult(int id, LabResult labResult);
        void DeleteLabResult(int id);
        IEnumerable<LabResult> SearchLabResults(string search);
    }
}


