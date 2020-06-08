using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApiLogin.Helpers;
using ApiLogin.Models;
using Microsoft.Extensions.Options;

namespace ApiLogin.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SqlConnection _connectionString;

        public LoginRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString =new SqlConnection(connectionString.Value.DbConnection.ToString());
        }

        public User CheckLogin(string username, string password)
        {
            SqlParameter[] parameter = {
                                new SqlParameter("@username",Convert.ToString( username)),
                                new SqlParameter("@password", Convert.ToString(password))
                                };

            DataSet ds = SqlHelper.ExecuteDataset(_connectionString,CommandType.StoredProcedure, "Login_Check", parameter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Common.ConvertDataTable<User>(ds.Tables[0])[0];
            }
            else
            {
                return null;
            }
        }
    }
}
