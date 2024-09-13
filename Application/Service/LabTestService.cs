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
    public class LabTestService : ILabTestService
    {
        private readonly ILabTestRepository _labTestRepository;

        public LabTestService(ILabTestRepository labTestRepository)
        {
            _labTestRepository = labTestRepository;
        }

        public IEnumerable<LabTest> ViewLabTests()
        {
            return _labTestRepository.View();
        }

        public LabTest GetLabTestById(int id)
        {
            return _labTestRepository.View().FirstOrDefault(l => l.Id == id);
        }

        public void AddLabTest(LabTest labTest)
        {
            _labTestRepository.Add(labTest);
        }

        public void UpdateLabTest(int id, LabTest labTest)
        {
            _labTestRepository.Update(id, labTest);
        }

        public void DeleteLabTest(int id)
        {
            _labTestRepository.Delete(id);
        }
    }
}
