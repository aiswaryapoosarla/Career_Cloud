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
    public class SecurityLoginRepository : IDataRepository<SecurityLoginPoco>
    {
        private readonly string connectionString;

        public SecurityLoginRepository()
        {

            connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True";
        }
        public void Add(params SecurityLoginPoco[] items)
        {
            foreach (var item in items)
            {

                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Security_Logins(Id,Login,Password,Created_Date,Password_Update_Date,Agreement_Accepted_Date,Is_Locked,Is_Inactive,Email_Address,Phone_Number,Full_Name,Force_Change_Password,Prefferred_Language)" +
                                          "values(@Id,@Login,@Password,@CreatedDate,@PasswordUpdateDate,@AgreementAcceptedDate,@IsLocked,@IsInactive,@EmailAddress,@PhoneNumber,@FullName,@ForceChangePassword,@PrefferredLanguage)";


                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@CreatedDate", item.Created);
                    cmd.Parameters.AddWithValue("@PasswordUpdateDate", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@AgreementAcceptedDate", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@IsLocked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@EmailAddress", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@ForceChangePassword", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@PrefferredLanguage", item.PrefferredLanguage);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Security_Logins", conn)).ExecuteReader();

                var securityLogins = new List<SecurityLoginPoco>();
                while (r.Read())
                {
                    securityLogins.Add(new SecurityLoginPoco()
                    {
                        Id = (Guid)r["Id"],
                        Login = (string)r["Login"],
                        Password = (string)r["Password"],
                        Created = (DateTime)r["Created_Date"],
                        //PasswordUpdate = (DateTime)r["Password_Update_Date"],
                        PasswordUpdate = r.IsDBNull(r.GetOrdinal("Password_Update_Date")) ? (DateTime?)null : (DateTime)r["Password_Update_Date"],
                        //AgreementAccepted = (DateTime)r["Agreement_Accepted_Date"],
                        AgreementAccepted = r.IsDBNull(r.GetOrdinal("Agreement_Accepted_Date")) ? (DateTime?)null : (DateTime)r["Agreement_Accepted_Date"],
                        IsLocked = (bool)r["Is_Locked"],
                        IsInactive = (bool)r["Is_Inactive"],
                        EmailAddress = (string)r["Email_Address"],
                        //PhoneNumber = (string)r["Phone_Number"],
                        PhoneNumber = r.IsDBNull(r.GetOrdinal("Phone_Number")) ? (string?)null : (string)r["Phone_Number"],
                        FullName = (string)r["Full_Name"],
                        ForceChangePassword = (bool)r["Force_Change_Password"],
                        //PrefferredLanguage= (string)r["Prefferred_Language"]
                        PrefferredLanguage = r.IsDBNull(r.GetOrdinal("Prefferred_Language")) ? (string?)null : (string)r["Prefferred_Language"]

                    }
                    );
                }
                return securityLogins;
            }
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();

            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Security_Logins where Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (var item in items)
                {

                    var cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Update Security_Logins set " +
                                      "Login = @Login," +
                                      "Password = @Password," +
                                      "Created_Date = @CreatedDate," +
                                      "Password_Update_Date = @PasswordUpdateDate," +
                                      "Agreement_Accepted_Date = @AgreementAcceptedDate," +
                                      "Is_Locked = @IsLocked," +
                                      "Is_Inactive = @IsInactive," +
                                      "Email_Address = @EmailAddress," +
                                      "Phone_Number = @PhoneNumber," +
                                      "Full_Name = @FullName," +
                                      "Force_Change_Password = @ForceChangePassword," +
                                      "Prefferred_Language = @PrefferredLanguage " +

                                      "where Id =@Id";

                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@CreatedDate", item.Created);
                    cmd.Parameters.AddWithValue("@PasswordUpdateDate", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@AgreementAcceptedDate", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@IsLocked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@IsInactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@EmailAddress", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@PhoneNumber", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@FullName", item.FullName);
                    cmd.Parameters.AddWithValue("@ForceChangePassword", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@PrefferredLanguage", item.PrefferredLanguage);


                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
