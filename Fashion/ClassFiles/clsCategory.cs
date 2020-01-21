using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.ClassFiles
{
    public class clsCategory : Connections
    {
        public int? CategoryId;
        public string Action, CategoryName, Description;


        public DataSet fnCategory()
        {
            try
            {
                Connect();
                cmd.Connection = con;
                cmd.CommandText = "SP_Category";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CategoryId", CategoryId);
                cmd.Parameters.AddWithValue("CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("Description", Description);
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