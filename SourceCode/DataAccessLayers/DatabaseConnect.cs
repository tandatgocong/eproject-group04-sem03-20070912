using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace DataAccessLayers
{
    public  class DatabaseConnect
    {
        public  SqlConnection conn;        
        public  DatabaseConnect()
        {
            conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BOOKONLINEConnectionString"].ConnectionString);
        }
        public  DataTable CreateDataTable(string Query)
        {
            SqlDataAdapter adt = new SqlDataAdapter(Query, conn);
            DataTable Result = new DataTable();
            adt.Fill(Result);
            return Result;
        }
        public  DataTable CreateDataTable(string Query, SqlParameter[] Params)
        {
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddRange(Params);
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataTable Result = new DataTable();
            adt.Fill(Result);
            return Result;
        }
        public  int ExcuteNonQuery(string Query, SqlParameter[] Params)
        {
            //try
            //{
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddRange(Params);
                return cmd.ExecuteNonQuery();
            //}
            //catch (Exception)
            //{
            //    return 0;
            //}
            //finally
            //{
            //    conn.Close();
            //}
            
        }
    }
}
