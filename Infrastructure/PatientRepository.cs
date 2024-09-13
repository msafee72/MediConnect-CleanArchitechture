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
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        List<Patient> _patients = new List<Patient>();

        IRepository<Patient> _patientsRepository = new GenericRepository<Patient>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");

        private readonly string _connString;

        public PatientRepository(string conn) : base(conn)
        {
            _connString = conn;
        }

        public void Add(Patient patient)
        {
            _patientsRepository.Add(patient);

            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";
            //    SqlConnection con = new SqlConnection(connection);
            //    con.Open();

            //    string query = $"INSERT INTO Patient (PatientName, Contact, Gender, DOB, Weight, Age, HealthConditions, Diseases) " +
            //                   $"VALUES (@PatientName, @Contact, @Gender, @DOB, @Weight, @Age, @HealthConditions, @Diseases)";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
            //    cmd.Parameters.AddWithValue("@Contact", patient.Contact);
            //    cmd.Parameters.AddWithValue("@Gender", patient.Gender);
            //    cmd.Parameters.AddWithValue("@DOB", patient.DOB);
            //    cmd.Parameters.AddWithValue("@Weight", patient.Weight);
            //    cmd.Parameters.AddWithValue("@Age", patient.Age);
            //    cmd.Parameters.AddWithValue("@HealthConditions", patient.HealthConditions);
            //    cmd.Parameters.AddWithValue("@Diseases", patient.Diseases);

            //    int rowsAffected = cmd.ExecuteNonQuery();
            //    con.Close();
            //    if (rowsAffected > 0)
            //    {
            //        Console.WriteLine("Patient Added!");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }


        public IEnumerable<Patient> View()
        {
            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True";

            //    SqlConnection con = new SqlConnection(connection);
            //    con.Open();
            //    string read = "SELECT * FROM Patient";

            //    SqlCommand cmd = new SqlCommand(read, con);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Patient patient = new Patient
            //        {
            //            Id = (int)reader[0],
            //            PatientName = (string)reader[1],
            //            Contact = (string)reader[2],
            //            Gender = (string)reader[3],
            //            DOB = DateTime.Parse(reader[4].ToString()),
            //            Weight = (decimal)reader[5],
            //            Age = (int)reader[6],
            //            HealthConditions = reader[7] != DBNull.Value ? (string)reader[7] : null,
            //            Diseases = reader[8] != DBNull.Value ? (string)reader[8] : null
            //        };
            //        _patients.Add(patient);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //return _patients;

            return (List<Patient>)_patientsRepository.GetAll();

        }


        public void Update(int patientId, Patient patient)
        {

            _patientsRepository.Update(patient);

            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";

            //    SqlConnection con = new SqlConnection(connection);

            //    con.Open();

            //    string query = "UPDATE Patient SET PatientName = @PatientName, Contact = @Contact, Gender = @Gender, " +
            //                   "DOB = @DOB, Weight = @Weight, Age = @Age, HealthConditions = @HealthConditions, " +
            //                   "Diseases = @Diseases WHERE PatientId = @PatientId";

            //    SqlCommand cmd = new SqlCommand(query, con);

            //    cmd.Parameters.AddWithValue("@Id", patient.Id);
            //    cmd.Parameters.AddWithValue("@PatientName", patient.PatientName);
            //    cmd.Parameters.AddWithValue("@Contact", patient.Contact);
            //    cmd.Parameters.AddWithValue("@Gender", patient.Gender);
            //    cmd.Parameters.AddWithValue("@DOB", patient.DOB);
            //    cmd.Parameters.AddWithValue("@Weight", patient.Weight);
            //    cmd.Parameters.AddWithValue("@Age", patient.Age);
            //    cmd.Parameters.AddWithValue("@HealthConditions", string.IsNullOrEmpty(patient.HealthConditions) ? (object)DBNull.Value : patient.HealthConditions);
            //    cmd.Parameters.AddWithValue("@Diseases", string.IsNullOrEmpty(patient.Diseases) ? (object)DBNull.Value : patient.Diseases);

            //    int rowsAffected = cmd.ExecuteNonQuery();

            //    if (rowsAffected > 0)
            //    {
            //        Console.WriteLine("Patient Updated!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        public void Delete(int patientId)
        {
            _patientsRepository.Delete(patientId);

            //    try
            //    {
            //        string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";

            //        SqlConnection con = new SqlConnection(connection);

            //        con.Open();

            //        string query = "DELETE FROM Patient WHERE Id = @Id";

            //        SqlCommand cmd = new SqlCommand(query, con);

            //        cmd.Parameters.AddWithValue("@Id", Id);

            //        int rowsAffected = cmd.ExecuteNonQuery();

            //        if (rowsAffected > 0)
            //        {
            //            Console.WriteLine("Patient Deleted!");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}


        }
    }
}
