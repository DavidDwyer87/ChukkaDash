using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ChukkaDashB.Areas.Promo.Models
{
    
    public class NewPromo
    {
        SqlConnection conn = null;

        public NewPromo()
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();
            }
            catch(Exception ex)
            {

            }
        }

        public void NewPromo(string mode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {

                }

                dr.Close();
            }
            catch(Exception ex)
            {

            }
        }
    }
}