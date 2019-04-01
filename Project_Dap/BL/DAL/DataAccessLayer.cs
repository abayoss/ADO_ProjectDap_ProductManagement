using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Project_Dap.BL.DAL
{
    class DataAccessLayer
    {
       public SqlConnection sqlConnection;

        //This Constructor Inisialize the connection object
        public DataAccessLayer()
        {
           sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=Product_DB;Integrated Security=True");
        }
        //Method to open the connection
        public void Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        //Method to Close the connection
        public void close()
        {
            if(sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        //Method To Read Data From Database
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;

            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Method to Insert, Update, and Delete Data From Database
        public void ExecuteCommand (string stored_procedure,SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlConnection;

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }

    }
}
