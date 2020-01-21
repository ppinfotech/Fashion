using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.ClassFiles
{
    public class clsColor : Connections
    {        
        public string Action;


        public DataSet fnColor()
        {
            try
            {
                Connect();
                cmd.Connection = con;
                cmd.CommandText = "SP_Color";
                cmd.CommandType = CommandType.StoredProcedure;                
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