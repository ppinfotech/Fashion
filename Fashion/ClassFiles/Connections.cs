using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fashion.ClassFiles
{
    public class Connections
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter da;
        public DataSet ds;
        public DataTable dt;

        public void Connect()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            cmd = new SqlCommand();
            SqlConnection.ClearPool(con);
            con.Open();
            da = new SqlDataAdapter();
            ds = new DataSet();
        }
        public void disconnect()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public string MainConnStr()
        {
            string Connstr = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            return Connstr;
        }
    }
}