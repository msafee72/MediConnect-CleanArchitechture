using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ILaboratorianRepository : IRepository<Laboratorian>
    {
        //public void Add(Laboratorian l);

        public IEnumerable<Laboratorian> View();

        public void Update(int id, Laboratorian l);

        //public void Delete(int id);
    }

}
