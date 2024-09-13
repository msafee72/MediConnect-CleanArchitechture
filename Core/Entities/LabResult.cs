using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Entities
{
    public class LabResult
    {
        public int Id { get; set; }
        public int PatientId { get; set; }

        public string TestName { get; set; }

        public IFormFile File { get; set; }
        public string ResultFilePath { get; set; }

    }
}
