using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.ClassFiles
{
    public class clsFabric : Connections
    {
        public int? FabricId, CategoryId;
        public string Action, FabricName, Description, ImagePath;

        public DataSet fnFabric()
        {
            try
            {
                Connect();
                cmd.Connection = con;
                cmd.CommandText = "SP_Fabric";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("FabricId", FabricId);
                cmd.Parameters.AddWithValue("CategoryId", CategoryId);
                cmd.Parameters.AddWithValue("FabricName", FabricName);
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