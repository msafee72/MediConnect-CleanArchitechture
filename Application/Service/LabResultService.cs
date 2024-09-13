using Application.Interface;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace Application
{
    public class LabResultService : ILabResultService
    {
        private readonly ILabResultRepository _labResultRepository;
        private readonly IFileStorageService _fileStorageService;

        public LabResultService(ILabResultRepository labResultRepository, IFileStorageService fileStorageService)
        {
            _labResultRepository = labResultRepository;
            _fileStorageService = fileStorageService;
        }

        public IEnumerable<LabResult> ViewLabResults()
        {
            return _labResultRepository.View();
        }

        public LabResult GetLabResultById(int id)
        {
            return _labResultRepository.View().FirstOrDefault(lr => lr.Id == id);
        }

        public void UploadLabResult(LabResult labResult, byte[] fileContent)
        {
            var filePath = _fileStorageService.SaveFile(fileContent, "labresults");
            labResult.ResultFilePath = filePath;
            _labResultRepository.Upload(labResult);
        }

        public void UpdateLabResult(int id, LabResult labResult)
        {
            _labResultRepository.Update(id, labResult);
        }

        public void DeleteLabResult(int id)
        {                                       
            _labResultRepository.Delete(id);
        }

        public IEnumerable<LabResult> SearchLabResults(string search)
        {
            return _labResultRepository.Search(search);
        }

    }
}



//using Application.Interface;
//using Core;
//using Core.Interfaces;


//namespace Application.Service
//{
//    public class LabResultService : ILabResultService
//    {
//        private readonly ILabResultRepository _labResultRepository;

//        public LabResultService(ILabResultRepository labResultRepository)
//        {
//            _labResultRepository = labResultRepository;
//        }

//        public IEnumerable<LabResult> ViewLabResults()
//        {
//            return _labResultRepository.View();
//        }

//        public LabResult GetLabResultById(int id)
//        {
//            return _labResultRepository.View().FirstOrDefault(l => l.Id == id);
//        }

//        public void UploadLabResult(LabResult labResult)
//        {
//            _labResultRepository.Upload(labResult);
//        }

//        public void UpdateLabResult(int id, LabResult labResult)
//        {
//            _labResultRepository.Update(id, labResult);
//        }

//        public void DeleteLabResult(int id)
//        {
//            _labResultRepository.Delete(id);
//        }

//        public IEnumerable<LabResult> SearchLabResults(string search)
//        {
//            return _labResultRepository.Search(search);
//        }
//    }
//}
