using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Laboratorian
    {
        public int Id { get; set; }
        public string LaboratorianName { get; set; }
        public string Contact { get; set; }

        //public int Experience { get; set; }
        //public string Specialization { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        //public string Address { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
