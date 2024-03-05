using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace My_Dapper_Project.Context
{
    public class HotelContext
    {
        private const string _connectionString = "Server=localhost;Database = hoteldb;User ID=root;Password=WADOOD091201,,..";

        public static IDbConnection Connection()
        {
            var connection = new SqlConnection(_connectionString);
            return connection;
        }
    }
}