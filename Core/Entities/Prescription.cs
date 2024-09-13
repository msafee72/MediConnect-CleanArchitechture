using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Prescription
    {
        public int Id { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public string Medicines { get; set; }
        public string LabTests { get; set; }

        public decimal Cost { get; set; }

    }

}
