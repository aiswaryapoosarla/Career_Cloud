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
    public class CompanyJobDescriptionRepository : IDataRepository<CompanyJobDescriptionPoco>
    {
        private readonly string connectionString;

        public CompanyJobDescriptionRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Company_Jobs_Descriptions(Id,Job,Job_Name,Job_Descriptions)" +
                                          "values(@Id,@Job,@JobName,@JobDescriptions)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@JobName", item.JobName);
                    cmd.Parameters.AddWithValue("@JobDescriptions", item.JobDescriptions);
                    
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Company_Jobs_Descriptions", conn)).ExecuteReader();

                var companyJobDescriptions = new List<CompanyJobDescriptionPoco>();
                while (r.Read())
                {
                    companyJobDescriptions.Add(new CompanyJobDescriptionPoco()
                    {
                        Id = (Guid)r["Id"],
                        Job = (Guid)r["Job"],
                        JobName = (string)r["Job_Name"],
                        JobDescriptions= (string)r["Job_Descriptions"],
                       
                    }
                    );
                }
                return companyJobDescriptions;
            }
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Company_Jobs_Descriptions where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Jobs_Descriptions set " +
                                      "Job = @Job," +
                                      "Job_Name = @JobName," +
                                      "Job_Descriptions = @JobDescriptions " +
                                     
                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@JobName", item.JobName);
                    cmd.Parameters.AddWithValue("@JobDescriptions", item.JobDescriptions);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
