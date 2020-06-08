using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApiUserManagement.Helpers;
using ApiUserManagement.Models;
using Microsoft.Extensions.Options;

namespace ApiUserManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlConnection _connectionString;

        public UserRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString =new SqlConnection(connectionString.Value.DbConnection.ToString());
        }

        public bool DeleteUser(int userId)
        {
            SqlParameter[] parameter = {
                              
                                new SqlParameter("@UserId", userId)
                               

                                };


            SqlHelper.ExecuteNonQuery(_connectionString, "User_Delete", parameter);
            return true;
        }

        public List<User> GetAllUser()
        {
            

            DataSet ds= SqlHelper.ExecuteDataset(_connectionString,System.Data.CommandType.StoredProcedure, "User_GetAll");
            return Common.ConvertDataTable<User>(ds.Tables[0]);
        }

        public User GetUserByUserId(int userId)
        {
                            SqlParameter[] parameter = {
                                new SqlParameter("@UserId", userId)

                                };
 

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString, "User_GetAll", parameter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Common.ConvertDataTable<User>(ds.Tables[0])[0];
            }
            else
            {
                return new User();
            }
        }

        public bool InsertUser(User user)
        {

            SqlParameter[] parameter = {
                                new SqlParameter("@Address", user.Address)
                                ,new SqlParameter("@FullName", user.FullName)
                                ,new SqlParameter("@Password", user.Password)
                                ,new SqlParameter("@PhoneNo", user.PhoneNo)
                          
                                ,new SqlParameter("@Username", user.Username)

                                };


             SqlHelper.ExecuteNonQuery(_connectionString, "User_Insert", parameter);
            return true;
        }

        public bool UpdateUser(User user)
        {
            SqlParameter[] parameter = {
                                new SqlParameter("@Address", user.Address)
                                ,new SqlParameter("@FullName", user.FullName)
                                ,new SqlParameter("@Password", user.Password)
                                ,new SqlParameter("@PhoneNo", user.PhoneNo)
                                ,new SqlParameter("@UserId", user.UserId)
                                ,new SqlParameter("@Username", user.Username)

                                };


            SqlHelper.ExecuteNonQuery(_connectionString, "User_Update", parameter);
            return true;
        }
    }
}
