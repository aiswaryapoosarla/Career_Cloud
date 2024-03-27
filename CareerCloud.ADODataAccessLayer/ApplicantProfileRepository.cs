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
    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>
    {
        private readonly string connectionString;

        public ApplicantProfileRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
        public void Add(params ApplicantProfilePoco[] items)
        {
            foreach (var item in items)
            {
                
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Profiles(Id,Login,Country_Code,Zip_Postal_Code,Street_Address,City_Town,State_Province_Code,Currency,Current_Rate,Current_Salary)" +
                                          "values(@Id,@Login,@CountryCode,@ZipPostalCode,@StreetAddress,@CityTown,@StateProvinceCode,@Currency,@CurrentRate,@CurrentSalary)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@CountryCode", item.Country);
                    cmd.Parameters.AddWithValue("@ZipPostalCode", item.PostalCode);
                    cmd.Parameters.AddWithValue("@StreetAddress", item.Street);
                    cmd.Parameters.AddWithValue("@CityTown", item.City);
                    cmd.Parameters.AddWithValue("@StateProvinceCode", item.Province);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@CurrentRate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@CurrentSalary", item.CurrentSalary);


                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Applicant_Profiles", conn)).ExecuteReader();

                var applicantprofiles = new List<ApplicantProfilePoco>();
                while (r.Read())
                {
                    applicantprofiles.Add(new ApplicantProfilePoco()
                    {
                        Id = (Guid)r["Id"],
                        Login = (Guid)r["Login"],
                        Country = (string) r["Country_Code"],
                        PostalCode = (string) r["Zip_Postal_Code"],
                        Street = (string) r["Street_Address"],
                        City = (string) r["City_Town"],
                        Province = (string) r["State_Province_Code"],
                        Currency = (string) r["Currency"],
                        CurrentRate = (decimal) r["Current_Rate"],
                        CurrentSalary = (decimal) r["Current_Salary"]

                    }
                    );
                }
                return applicantprofiles;
            }
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Applicant_Profiles where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Applicant_Profiles set " +
                                      "Login = @Login," +
                                      "Country_Code = @CountryCode," +
                                      "Zip_Postal_Code = @ZipPostalCode," +
                                      "Street_Address = @StreetAddress," +
                                      "City_Town = @CityTown," +
                                      "State_Province_Code = @StateProvinceCode," +
                                      "Currency = @Currency," +
                                      "Current_Rate = @CurrentRate," +
                                      "Current_Salary = @CurrentSalary " +

                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@CountryCode", item.Country);
                    cmd.Parameters.AddWithValue("@ZipPostalCode", item.PostalCode);
                    cmd.Parameters.AddWithValue("@StreetAddress", item.Street);
                    cmd.Parameters.AddWithValue("@CityTown", item.City);
                    cmd.Parameters.AddWithValue("@StateProvinceCode", item.Province);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@CurrentRate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@CurrentSalary", item.CurrentSalary);


                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
