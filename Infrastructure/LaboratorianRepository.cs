using Core.Interfaces;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure
{
    public class LaboratorianRepository : GenericRepository<Laboratorian>, ILaboratorianRepository
    {

        List<Laboratorian> _laboratorian = new List<Laboratorian>();


        IRepository<Laboratorian> _laboratoriansRepository = new GenericRepository<Laboratorian>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");

        private readonly object _laboratorianRepository;



        private readonly string _connString;
        public LaboratorianRepository(string conn) : base(conn)
        {
            _connString = conn;
        }


        public void Add(Laboratorian l)
        {
            _laboratoriansRepository.Add(l);

        }

        public IEnumerable<Laboratorian> View()
        {


            return _laboratoriansRepository.GetAll();
        }

        public void Update(int id, Laboratorian l)
        {


            _laboratoriansRepository.Update(l);
        }

        public void Delete(int id)
        {
            _laboratoriansRepository.Delete(id);
        }

    }
}
