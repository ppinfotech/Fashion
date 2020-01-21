using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.ClassFiles
{
    public class clsAdmin : Connections
    {
        public int AdminId, IsSuperAdmin;
        public string UserName, Password, Action;

        //public int AdminId
        //{
        //    get { return _AdminId; }
        //    set { _AdminId = value; }
        //}
        public DataSet fnAdmin()
        {
            try
            {
                Connect();
                cmd.Connection = con;
                cmd.CommandText = "SP_Admin";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AdminId", AdminId);
                cmd.Parameters.AddWithValue("IsSuperAdmin", IsSuperAdmin);
                cmd.Parameters.AddWithValue("UserName", UserName);
                cmd.Parameters.AddWithValue("Password", Password);
                cmd.Parameters.AddWithValue("Action", Action);
                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                disconnect();
                return ds;
            }
            catch (Exception ex)
            {
                return ds;
            }
        }
    }
}