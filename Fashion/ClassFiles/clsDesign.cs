using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.ClassFiles
{
    public class clsDesign : Connections
    {
        public int? DesignId;
        public string Action, DesignName, Description, ImagePath;


        public DataSet fnDesign()
        {
            try
            {
                Connect();
                cmd.Connection = con;
                cmd.CommandText = "SP_Design";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("DesignId", DesignId);
                cmd.Parameters.AddWithValue("DesignName", DesignName);
                cmd.Parameters.AddWithValue("Description", Description);
                cmd.Parameters.AddWithValue("ImagePath", ImagePath);
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