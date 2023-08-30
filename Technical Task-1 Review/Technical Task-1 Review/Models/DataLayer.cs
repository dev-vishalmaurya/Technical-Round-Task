using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Technical_Task_1_Review.Models
{
    public class DataLayer
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        public int ExecutedbQuery(string spproc, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(spproc, conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            conn.Open();
            foreach (SqlParameter param in parameters)
            {
                cmd.Parameters.Add(param);
            }
            int a = cmd.ExecuteNonQuery();
            conn.Close();

            return a;
        }
        public DataTable GetTables(string proc, SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(proc, conn);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter param in parameters)
            {
                command.Parameters.Add(param);
            }
            conn.Open();
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }
    }

}