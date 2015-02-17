using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ChukkaDashB.Areas.GpReport.Models
{
    public class GpReportingModel
    {
        SqlConnection conn = null;
        public GpReportingModel()
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();
            }
            catch(SqlException ex)
            {

            }
        }

        public void reporting(string from,string to,string filter,GpModel gp)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec GpReport '"+from+"','"+to+"','"+filter+"'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                gp.data = new List<TableData>();
                gp.total = new TotalData();

                int num = 1;

                while(dr.Read())
                {
                    if (!string.IsNullOrEmpty(dr.GetValue(2).ToString()))
                    {
                        gp.data.Add(new TableData { 
                            index = num++,
                            CustomerID = dr.GetValue(0).ToString(),
                            name = dr.GetValue(1).ToString(),
                            adult = Convert.ToInt32(dr.GetValue(2)),
                            children =  Convert.ToInt32(dr.GetValue(3)),
                            Pax = Convert.ToInt32(dr.GetValue(4)),
                        });

                        gp.total.adult = gp.total.adult + Convert.ToInt32(dr.GetValue(2));
                        gp.total.children = gp.total.adult + Convert.ToInt32(dr.GetValue(3));
                        gp.total.pax = gp.total.adult + Convert.ToInt32(dr.GetValue(4));                       
                    }
                }

                dr.Close();
            }
            catch(Exception ex)
            {

            }
        }
    }
}