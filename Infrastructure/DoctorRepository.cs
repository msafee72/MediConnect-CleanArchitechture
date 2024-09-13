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
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        List<Doctor> _doctors = new List<Doctor>();

        IRepository<Doctor> _doctorsRepository = new GenericRepository<Doctor>("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;");

        private readonly string _connString;

        public DoctorRepository(string conn) : base(conn)
        {
            _connString = conn;
        }

        public new void Add(Doctor doctor)
        {

            _doctorsRepository.Add(doctor);

            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";
            //    SqlConnection con = new SqlConnection(connection);
            //    con.Open();

            //    string query = $"insert into Doctor values(@DoctorName,@Contact,@Experience,@Specialization,@Gender,@Address,@DOB,@Email,@Password)";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    //cmd.Parameters.AddWithValue("@Id", doctor.DoctorId);
            //    cmd.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
            //    cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
            //    cmd.Parameters.AddWithValue("@Experience", doctor.Experience);
            //    cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
            //    cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
            //    cmd.Parameters.AddWithValue("@Address", doctor.Address);
            //    cmd.Parameters.AddWithValue("@DOB", doctor.DOB);
            //    cmd.Parameters.AddWithValue("@Email", doctor.Email);
            //    cmd.Parameters.AddWithValue("@Password", doctor.Password);

            //    int rowsAffected = cmd.ExecuteNonQuery();
            //    con.Close();
            //    if (rowsAffected > 0)
            //    {
            //        Console.WriteLine("Doctor Added!");
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }



        public IEnumerable<Doctor> View()
        {

            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True";
            //    SqlConnection con = new SqlConnection(connection);
            //    con.Open();
            //    string read = "select * from Doctor";
            //    SqlCommand cmd = new SqlCommand(read, con);
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Doctor m = new Doctor
            //        {
            //            Id = (int)reader[0],
            //            DoctorName = (string)reader[1],
            //            Contact = (string)reader[2],
            //            Experience = (int)reader[3],
            //            Specialization = (string)reader[4],
            //            Gender = (string)reader[5],
            //            Address = (string)reader[6],
            //            DOB = DateTime.Parse(reader[7].ToString()),
            //            Email = reader[8].ToString(),
            //            Password = reader[9].ToString()
            //        };
            //        _doctors.Add(m);
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            return _doctorsRepository.GetAll();

        }


        public void Update(int doctorID, Doctor doctor)
        {

            _doctorsRepository.Update(doctor);


            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";

            //    using (SqlConnection con = new SqlConnection(connection))
            //    {
            //        con.Open();

            //        string query = @"UPDATE Doctor SET DoctorName=@DoctorName,Contact=@Contact,Experience=@Experience, 
            //                     Specialization=@Specialization, Gender=@Gender, Address=@Address, 
            //                     DOB=@DOB, Email=@Email, Password=@Password 
            //                     WHERE Id=@Id";


            //        using (SqlCommand cmd = new SqlCommand(query, con))
            //        {
            //            cmd.Parameters.AddWithValue("@Id", doctorID);
            //            cmd.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
            //            cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
            //            cmd.Parameters.AddWithValue("@Experience", doctor.Experience);
            //            cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
            //            cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
            //            cmd.Parameters.AddWithValue("@Address", doctor.Address);
            //            cmd.Parameters.AddWithValue("@DOB", doctor.DOB);
            //            cmd.Parameters.AddWithValue("@Email", (object)doctor.Email ?? DBNull.Value);
            //            cmd.Parameters.AddWithValue("@Password", (object)doctor.Password ?? DBNull.Value);

            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }



        public new void Delete(int doctorID)
        {
            _doctorsRepository.Delete(doctorID);

            //try
            //{
            //    string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;";
            //    SqlConnection con = new SqlConnection(connection);
            //    con.Open();

            //    string query = "delete from Doctor where Id = @Id";
            //    SqlCommand cmd = new SqlCommand(query, con);

            //    cmd.Parameters.AddWithValue("@Id", doctorID);

            //    int rowsAffected = cmd.ExecuteNonQuery();

            //    if (rowsAffected > 0)
            //    {
            //        Console.WriteLine("Doctor Deleted!");
            //    }
            //}

            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


        }

    }
}
