using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILabTestService
    {
        IEnumerable<LabTest> ViewLabTests();
        LabTest GetLabTestById(int id);
        void AddLabTest(LabTest labTest);
        void UpdateLabTest(int id, LabTest labTest);
        void DeleteLabTest(int id);
    }
}

