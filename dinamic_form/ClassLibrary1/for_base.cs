using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibrary1
{
    public class for_base
    {
        private static string ConnectionString;
        public SqlConnection connection;
        private string sqlExpression = "";
        public SqlCommand command;
        public SqlDataReader reader;

        public for_base(string sqlExpression, string Connection_String)
        {
            ConnectionString = Connection_String;
            smena_zaprosa(sqlExpression);
        }

        public void connection_open()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public void connection_close()
        {
            connection.Close();
        }

        public void proverka_znachenei_v_bd()
        {
            command = new SqlCommand(sqlExpression, connection);
            reader = command.ExecuteReader();
        }

        public void smena_zaprosa(string sqlExpression)
        {
            this.sqlExpression = sqlExpression;
        }
    }
}
