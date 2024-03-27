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
    public class CompanyJobRepository : IDataRepository<CompanyJobPoco>
    {
        private readonly string connectionString;

        public CompanyJobRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }

        public void Add(params CompanyJobPoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Company_Jobs(Id,Company,Profile_Created,Is_Inactive,Is_Company_Hidden)" +
                                          "values(@Id,@Company,@ProfileCreated,@IsInactive,@IsCompanyHidden)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@ProfileCreated", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@IsCompanyHidden", item.IsCompanyHidden);

                    cmd.ExecuteNonQuery();
                }

                }
            }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Company_Jobs", conn)).ExecuteReader();

                var companyJobs = new List<CompanyJobPoco>();
                while (r.Read())
                {
                    companyJobs.Add(new CompanyJobPoco()
                    {
                        Id = (Guid)r["Id"],
                        Company = (Guid)r["Company"],
                        ProfileCreated = (DateTime)r["Profile_Created"],
                        IsInactive = (bool)r["Is_Inactive"],
                        IsCompanyHidden = (bool)r["Is_Company_Hidden"]
                        
                    }
                    );
                }
                return companyJobs;
            }
        }

        public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Company_Jobs where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params CompanyJobPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Jobs set " +
                                      "Company = @Company," +
                                      "Profile_Created = @ProfileCreated," +
                                      "Is_Inactive = @IsInactive," +
                                      "Is_Company_Hidden = @IsCompanyHidden " +
                                    
                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@ProfileCreated", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@IsCompanyHidden", item.IsCompanyHidden);
                   
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
