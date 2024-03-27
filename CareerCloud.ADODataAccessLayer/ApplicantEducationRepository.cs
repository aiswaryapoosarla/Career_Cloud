using CareerCloud.DataAccessLayer;
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
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        private readonly string connectionString;

        public ApplicantEducationRepository()
        {
            
            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
    

        public void Add(params ApplicantEducationPoco[] items)
        {
            foreach (var item in items)
            {
                
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Educations(Id,Applicant,Certificate_Diploma,Major,Start_Date,Completion_Date,Completion_Percent)" +
                                          "values(@Id,@Applicant,@CertificateDiploma,@Major,@StartDate,@CompletionDate,@CompletionPercent)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                    cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);
                    
                    
                    
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataReader r = (new SqlCommand("Select * from Applicant_Educations", conn)).ExecuteReader();

                    var applicanteducations = new List<ApplicantEducationPoco>();
                    while (r.Read())
                    {
                        applicanteducations.Add(new ApplicantEducationPoco()
                        {
                            Id = (Guid)r["Id"],
                            Applicant = (Guid)r["Applicant"],
                            CertificateDiploma = (string)r["Certificate_Diploma"],
                            Major = (string)r["Major"],
                            StartDate = (DateTime)r["Start_Date"],
                            CompletionDate = (DateTime)r["Completion_Date"],
                            CompletionPercent = (byte)r["Completion_Percent"]
                            
                        }
                        );
                    }
                    return applicanteducations;
                }

        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }
        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)

        {

                IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();

                return pocos.Where(where).FirstOrDefault();

        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            
                using (var conn = new SqlConnection(connectionString))
                {
                     conn.Open();
                    foreach (var item in items)
                    {
                        var cmd = new SqlCommand();
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "Delete from Applicant_Educations where Id = @Id";

                        cmd.Parameters.AddWithValue("@Id", item.Id);

                        cmd.ExecuteNonQuery();

                    }
                }
            
            
        }

        public void Update(params ApplicantEducationPoco[] items)
        {

                using (var conn = new SqlConnection(connectionString))
                {
                conn.Open();
                foreach (var item in items)
                   { 

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Educations set " +
                                      "Applicant = @Applicant," +
                                      "Certificate_Diploma = @CertificateDiploma," +
                                      "Major = @Major," +
                                      "Start_Date = @StartDate," +
                                      "Completion_Date = @CompletionDate," +
                                      "Completion_Percent = @CompletionPercent " +

                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@CertificateDiploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@StartDate", item.StartDate);
                    cmd.Parameters.AddWithValue("@CompletionDate", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@CompletionPercent", item.CompletionPercent);
                    

                    
                    cmd.ExecuteNonQuery();
                    }
                }
            
        }
    }
}
