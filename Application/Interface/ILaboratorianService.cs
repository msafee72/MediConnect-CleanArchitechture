using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILaboratorianService
    {

        Laboratorian GetLaboratorianById(int id);
        IEnumerable<Laboratorian> GetAllLaboratorians();
        void AddLaboratorian(Laboratorian laboratorian);
        void UpdateLaboratorian(int id, Laboratorian laboratorian);
        void DeleteLaboratorian(int id);
    }

}
