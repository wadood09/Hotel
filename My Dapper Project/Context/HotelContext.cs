using System.Data;
using MySql.Data.MySqlClient;

namespace My_Dapper_Project.Context
{
    public class HotelContext
    {
        private const string _connectionString = "Server=localhost;Database = hoteldb;User ID=root;Password=WADOOD091201,,..";

        public static IDbConnection Connection()
        {
            var connection = new MySqlConnection(_connectionString);
            return connection;
        }
    }
}