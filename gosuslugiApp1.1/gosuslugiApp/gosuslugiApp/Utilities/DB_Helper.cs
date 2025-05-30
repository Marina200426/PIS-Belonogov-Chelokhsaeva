using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gosuslugiApp;
using Npgsql;

public class DatabaseHelper
{
    string connectionString = "Host=localhost;Port=5433;Database=pis;Username=postgres;Password=123";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }

    public NpgsqlDataReader ExecuteQuery(string query, Dictionary<string, object> parameters)
    {
        var conn = GetConnection();
        conn.Open();
        using (var cmd = new NpgsqlCommand(query, conn))
        {
            foreach (var param in parameters)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            }
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
    }

    public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                return cmd.ExecuteNonQuery();
            }
        }
    }
}