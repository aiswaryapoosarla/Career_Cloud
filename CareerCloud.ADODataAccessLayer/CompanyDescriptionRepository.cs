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
    public class CompanyDescriptionRepository : IDataRepository<CompanyDescriptionPoco>
    {
        private readonly string connectionString;

        public CompanyDescriptionRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }

        public void Add(params CompanyDescriptionPoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Company_Descriptions(Id,LanguageId,Company,Company_Name,Company_Description)" +
                                          "values(@Id,@LanguageId,@Company,@CompanyName,@CompanyDescription)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@LanguageId", item.LanguageId);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyDescription", item.CompanyDescription);
                    
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Company_Descriptions", conn)).ExecuteReader();

                var companydescriptions = new List<CompanyDescriptionPoco>();
                while (r.Read())
                {
                    companydescriptions.Add(new CompanyDescriptionPoco()
                    {
                        Id = (Guid)r["Id"],
                        LanguageId = (string)r["LanguageId"],
                        Company = (Guid)r["Company"],
                        CompanyName = (string)r["Company_Name"],
                        CompanyDescription = (string)r["Company_Description"]
                        
                    }
                    );
                }
                return companydescriptions;
            }
        }

        public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Company_Descriptions where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Descriptions set " +
                                      "LanguageId = @LanguageId," +
                                      "Company = @Company," +
                                      "Company_Name = @CompanyName," +
                                      "Company_Description = @CompanyDescription " +
                                      
                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@LanguageId", item.LanguageId);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@CompanyName", item.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyDescription", item.CompanyDescription);
                   

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
