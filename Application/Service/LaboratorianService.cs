using Application.Interface;
using Core.Interfaces;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Application.Service
{
    public class LaboratorianService : ILaboratorianService
    {
        private readonly ILaboratorianRepository _laboratorianRepository;

        public LaboratorianService(ILaboratorianRepository laboratorianRepository)
        {
            _laboratorianRepository = laboratorianRepository;
        }

        public Laboratorian GetLaboratorianById(int id)
        {
            return _laboratorianRepository.View().FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Laboratorian> GetAllLaboratorians()
        {
            return _laboratorianRepository.View();
        }

        public void AddLaboratorian(Laboratorian laboratorian)
        {
            if (laboratorian == null)
                throw new ArgumentNullException(nameof(laboratorian));

            _laboratorianRepository.Add(laboratorian);
        }

        public void UpdateLaboratorian(int id, Laboratorian laboratorian)
        {
            if (laboratorian == null)
                throw new ArgumentNullException(nameof(laboratorian));

            _laboratorianRepository.Update(id, laboratorian);
        }

        public void DeleteLaboratorian(int id)
        {
            _laboratorianRepository.Delete(id);
        }
    }

}
