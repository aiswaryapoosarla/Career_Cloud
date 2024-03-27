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
    public class ApplicantWorkHistoryRepository : IDataRepository<ApplicantWorkHistoryPoco>
    {

        private readonly string connectionString;

        public ApplicantWorkHistoryRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Work_History(Id,Applicant,Country_Code,Company_Name,Location,Job_Title,Job_Description,Start_Month,Start_Year,End_Month,End_Year)" +
                                          "values(@Id,@Applicant,@CountryCode,@CompanyName,@Location,@JobTitle,@JobDescription,@StartMonth,@StartYear,@EndMonth,@EndYear)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                    cmd.Parameters.AddWithValue("@JobDescription", item.JobDescription);
                    cmd.Parameters.AddWithValue("@StartMonth", item.StartMonth);
                    cmd.Parameters.AddWithValue("@StartYear", item.StartYear);
                    cmd.Parameters.AddWithValue("@EndMonth", item.EndMonth);
                    cmd.Parameters.AddWithValue("@EndYear", item.EndYear);



                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Applicant_Work_History", conn)).ExecuteReader();

                var applicantworkhistory = new List<ApplicantWorkHistoryPoco>();
                while (r.Read())
                {
                    applicantworkhistory.Add(new ApplicantWorkHistoryPoco()
                    {
                        Id = (Guid)r["Id"],
                        Applicant = (Guid)r["Applicant"],
                        CountryCode = (string)r["Country_Code"],
                        CompanyName = (string)r["Company_Name"],
                        Location = (string)r["Location"],
                        JobTitle = (string)r["Job_Title"],
                        JobDescription = (string)r["Job_Description"],
                        StartMonth = (short)r["Start_Month"],
                        StartYear = (int)r["Start_Year"],
                        EndMonth = (short)r["End_Month"],
                        EndYear = (int)r["End_Year"]

                    }
                    );
                }
                return applicantworkhistory;
            }
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Applicant_Work_History where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Work_History set " +
                                      "Applicant = @Applicant," +
                                      "Country_Code = @CountryCode," +
                                      "Company_Name = @CompanyName," +
                                      "Location = @Location," +
                                      "Job_Title = @JobTitle," +
                                      "Job_Description = @JobDescription," +
                                      "Start_Month = @StartMonth," +
                                      "Start_Year = @StartYear," +
                                      "End_Month = @EndMonth," +
                                      "End_Year = @EndYear " +
                                      
                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@JobTitle", item.JobTitle);
                    cmd.Parameters.AddWithValue("@JobDescription", item.JobDescription);
                    cmd.Parameters.AddWithValue("@StartMonth", item.StartMonth);
                    cmd.Parameters.AddWithValue("@StartYear", item.StartYear);
                    cmd.Parameters.AddWithValue("@EndMonth", item.EndMonth);
                    cmd.Parameters.AddWithValue("@EndYear", item.EndYear);



                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
