using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Project_Dap.BL
{
    class CLS_LOGIN
    {
        public DataTable LOGIN (string ID, string PWD)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            param[1] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[1].Value = PWD;

            DAL.close();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("SP_LOGIN", param);
            return Dt;
        }

        public void ADD_USER(string ID, string FullName, string PWD,
                string UserType)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
            param[1].Value = FullName;

            param[2] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[2].Value = PWD;

            param[3] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            param[3].Value = UserType;


            DAL.ExecuteCommand("add_users", param);
            DAL.close();

        }



        public void EDIT_USER(string ID, string FullName, string PWD,
                string UserType)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            param[1] = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
            param[1].Value = FullName;

            param[2] = new SqlParameter("@PWD", SqlDbType.VarChar, 50);
            param[2].Value = PWD;

            param[3] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            param[3].Value = UserType;


            DAL.ExecuteCommand("EDIT_USER", param);
            DAL.close();

        }



        public void DELETE_USER(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            param[0].Value = ID;

            DAL.ExecuteCommand("DELETE_USER", param);
            DAL.close();

        }

        public DataTable SearchUsers(string Criterion)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@Criterion", SqlDbType.VarChar, 50);
            param[0].Value = Criterion;


            Dt = DAL.SelectData("SearchUsers", param);
            DAL.close();
            return Dt;
        }

    }
}
