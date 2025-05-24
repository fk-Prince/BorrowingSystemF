using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace BorrowingSystem
{
    public class DatabaseConnection
    {
        private  readonly string connectionString = "server=localhost;user=root;password=root;database=equipment_management_system";

        public  MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
