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
    public class SystemLanguageCodeRepository : IDataRepository<SystemLanguageCodePoco>
    {
        private readonly string connectionString;

        public SystemLanguageCodeRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
        public void Add(params SystemLanguageCodePoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into System_Language_Codes(LanguageID,Name,Native_Name)" +
                                          "values(@LanguageID,@Name,@NativeName)";


                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@NativeName", item.NativeName);
                   
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from System_Language_Codes", conn)).ExecuteReader();

                var systemLanguageCodes = new List<SystemLanguageCodePoco>();
                while (r.Read())
                {
                    systemLanguageCodes.Add(new SystemLanguageCodePoco()
                    {
                        LanguageID = (string)r["LanguageID"],
                        Name = (string)r["Name"],
                        NativeName = (string)r["Native_Name"]
                       
                    }
                    );
                }
                return systemLanguageCodes;
            }
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from System_Language_Codes where LanguageID = @LanguageID";

                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update System_Language_Codes set " +
                                      "Name = @Name," +
                                      "Native_Name = @NativeName " +
                                     
                                      "where LanguageID =@LanguageID";

                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@NativeName", item.NativeName);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
