﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantJobApplicationRepository : IDataRepository<ApplicantJobApplicationPoco>
    {
        private readonly string connectionString;

        public ApplicantJobApplicationRepository()
        {
           connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
       
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            
            foreach (var item in items) 
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Job_Applications(Id,Applicant,Job,Application_Date) " +
                                       "values(@Id,@Applicant,@Job,@ApplicationDate)";

                    cmd.Parameters.AddWithValue("@Id",item.Id);
                    cmd.Parameters.AddWithValue("@Applicant",item.Applicant);
                    cmd.Parameters.AddWithValue("@Job",item.Job);
                    cmd.Parameters.AddWithValue("@ApplicationDate",item.ApplicationDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Applicant_Job_Applications", conn)).ExecuteReader();

                var applicantjobapplications = new List<ApplicantJobApplicationPoco>();
                while (r.Read())
                {
                    applicantjobapplications.Add(new ApplicantJobApplicationPoco()
                    {
                        Id = (Guid)r["Id"],
                        Applicant = (Guid)r["Applicant"],
                        Job = (Guid)r["Job"],
                        ApplicationDate = (DateTime)r["Application_Date"],
                        TimeStamp = (byte[])r["Time_Stamp"]
                    }
                    );
                }
                return applicantjobapplications;
            }
        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {

                IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();

                return pocos.Where(where).FirstOrDefault();

          
        }

        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Applicant_Job_Applications where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Job_Applications set " +
                                      "Applicant = @Applicant," +
                                      "Job = @Job," +
                                      "Application_Date = @ApplicationDate " +
                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@ApplicationDate", item.ApplicationDate);


                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
