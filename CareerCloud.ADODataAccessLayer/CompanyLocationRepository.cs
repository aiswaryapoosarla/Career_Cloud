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
    public class CompanyLocationRepository : IDataRepository<CompanyLocationPoco>
    {
        private readonly string connectionString;

        public CompanyLocationRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
        public void Add(params CompanyLocationPoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Company_Locations(Id,Company,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code)" +
                                          "values(@Id,@Company,@CountryCode,@StateProvinceCode,@StreetAddress,@CityTown,@ZipPostalCode)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("@StateProvinceCode", item.Province);
                    cmd.Parameters.AddWithValue("@StreetAddress", item.Street);
                    cmd.Parameters.AddWithValue("@CityTown", item.City);
                    cmd.Parameters.AddWithValue("@ZipPostalCode", item.PostalCode);



                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Company_Locations", conn)).ExecuteReader();

                var companyLoactions = new List<CompanyLocationPoco>();
                while (r.Read())
                {
                    companyLoactions.Add(new CompanyLocationPoco()
                    {
                        Id = (Guid)r["Id"],
                        Company = (Guid)r["Company"],
                        CountryCode = (string)r["Country_Code"],
                        Province = (string)r["State_Province_Code"],
                        Street = (string)r["Street_Address"],
                        //City = (string)r["City_Town"],
                        City = r.IsDBNull(r.GetOrdinal("City_Town")) ? (string?)null : (string)r["City_Town"],
                        //PostalCode = (string)r["Zip_Postal_Code"]
                        PostalCode = r.IsDBNull(r.GetOrdinal("Zip_Postal_Code")) ? (string?)null : (string)r["Zip_Postal_Code"]

                    }
                    );
                }
                return companyLoactions;
            }
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Company_Locations where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Company_Locations set " +
                                      "Company = @Company," +
                                      "Country_Code = @CountryCode," +
                                      "State_Province_Code = @StateProvinceCode," +
                                      "Street_Address = @StreetAddress," +
                                      "City_Town = @CityTown," +
                                      "Zip_Postal_Code = @ZipPostalCode " +

                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@CountryCode", item.CountryCode);
                    cmd.Parameters.AddWithValue("@StateProvinceCode", item.Province);
                    cmd.Parameters.AddWithValue("@StreetAddress", item.Street);
                    cmd.Parameters.AddWithValue("@CityTown", item.City);
                    cmd.Parameters.AddWithValue("@ZipPostalCode", item.PostalCode);



                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
