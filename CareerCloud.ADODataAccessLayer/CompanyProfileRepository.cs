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
    public class CompanyProfileRepository : IDataRepository<CompanyProfilePoco>
    {
        private readonly string connectionString;

        public CompanyProfileRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }

        public void Add(params CompanyProfilePoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Company_Profiles(Id,Registration_Date,Company_Website,Contact_Phone,Contact_Name,Company_Logo)" +
                                          "values(@Id,@RegistrationDate,@CompanyWebsite,@ContactPhone,@ContactName,@CompanyLogo)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@RegistrationDate", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@CompanyWebsite", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@ContactPhone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@ContactName", item.ContactName);
                    cmd.Parameters.AddWithValue("@CompanyLogo", item.CompanyLogo);
                  
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Company_Profiles", conn)).ExecuteReader();

                var companyProfiles = new List<CompanyProfilePoco>();
                while (r.Read())
                {
                    companyProfiles.Add(new CompanyProfilePoco()
                    {
                        Id = (Guid)r["Id"],
                        RegistrationDate = (DateTime)r["Registration_Date"],
                        //CompanyWebsite = (string)r["Company_Website"],
                        CompanyWebsite = r.IsDBNull(r.GetOrdinal("Company_Website")) ? (string?)null : (string)r["Company_Website"],
                        ContactPhone = (string)r["Contact_Phone"],
                        //ContactName = (string)r["Contact_Name"],
                        ContactName = r.IsDBNull (r.GetOrdinal("Contact_Name")) ? (string?)null : (string)r["Contact_Name"],
                        //CompanyLogo = (byte[])r["Company_Logo"]
                        CompanyLogo = r.IsDBNull(r.GetOrdinal("Company_Logo")) ? (byte[]?)null : (byte[])r["Company_Logo"]
                       
                    }
                    );
                }
                return companyProfiles;
            }

        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Company_Profiles where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Profiles set " +
                                      "Registration_Date = @RegistrationDate," +
                                      "Company_Website = @CompanyWebsite," +
                                      "Contact_Phone = @ContactPhone," +
                                      "Contact_Name = @ContactName," +
                                      "Company_Logo = @CompanyLogo " +
                                     
                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@RegistrationDate", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@CompanyWebsite", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@ContactPhone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@ContactName", item.ContactName);
                    cmd.Parameters.AddWithValue("@CompanyLogo", item.CompanyLogo);
               
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
