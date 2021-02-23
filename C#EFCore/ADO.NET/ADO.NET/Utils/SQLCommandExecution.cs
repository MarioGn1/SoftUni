using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ADO.NET.Utils
{
    public class SQLCommandExecution
    {
        public int ExecuteNonQuery(SqlConnection connection, string[] statements)
        {
            foreach (var query in statements)
            {
                try
                {
                    var command = new SqlCommand(query, connection);
                    return command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
            return -1;
        }

        public int ExecuteNonQuery(SqlConnection connection, string query, Dictionary<string, object> parameters)
        {
            try
            {
                var command = new SqlCommand(query, connection);
                SetParameters(command, parameters);
                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public int ExecuteNonQuery(SqlConnection connection, string query, string parameterName, object parametersValue)
        {
            try
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue(parameterName, parametersValue);
                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public SqlDataReader ExecuteReader(SqlConnection connection, string query)
        {
            try
            {
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public SqlDataReader ExecuteReader(SqlConnection connection, string query, Dictionary<string, object> parameters)
        {
            try
            {
                var command = new SqlCommand(query, connection);
                SetParameters(command, parameters);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public object ExecuteScalar(string query, SqlConnection connection, Dictionary<string, object> parameters)
        {
            SqlCommand command = new SqlCommand(query, connection);
            SetParameters(command, parameters);
            return command.ExecuteScalar();
        }

        private void SetParameters(SqlCommand command, Dictionary<string, object> parameters)
        {
            foreach (var item in parameters)
            {
                command.Parameters.AddWithValue(item.Key, item.Value);
            }
        }
    }
}
