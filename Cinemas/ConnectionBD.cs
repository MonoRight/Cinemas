using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas
{
    class ConnectionBD
    {
        public SqlConnection BDConnection { get; set; }

        public ConnectionBD()
        {
            BDConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rainb\source\repos\Cinemas\Cinemas\Cinemas.mdf;Integrated Security=True");
        }

        public SqlConnection OpenDB()
        {
            try
            {
                // Открываем подключение
                BDConnection.Open();
                Console.WriteLine("\nConnection open\n");
                return BDConnection;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Close()
        {
            BDConnection.Close();
            Console.WriteLine("\nConnection close\n");
        }

    }
}
