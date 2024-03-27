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
    public class SystemCountryCodeRepository : IDataRepository<SystemCountryCodePoco>
    {
        private readonly string connectionString;

        public SystemCountryCodeRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }

        public void Add(params SystemCountryCodePoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into System_Country_Codes(Code,Name)" +
                                          "values(@Code,@Name)";


                    cmd.Parameters.AddWithValue("@Code", item.Code);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                   
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from System_Country_Codes", conn)).ExecuteReader();

                var systemCountryCodes = new List<SystemCountryCodePoco>();
                while (r.Read())
                {
                    systemCountryCodes.Add(new SystemCountryCodePoco()
                    {
                        Code = (string)r["Code"],
                        Name = (string)r["Name"] 
                       
                    }
                    );
                }
                return systemCountryCodes;
            }
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from System_Country_Codes where Code = @Code";

                    cmd.Parameters.AddWithValue("@Code", item.Code);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update System_Country_Codes set " +
                                      "Name = @Name " +
                                      
                                      "where Code =@Code";

                    cmd.Parameters.AddWithValue("@Code", item.Code);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                   
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
