using ChukkaDashB.Areas.Reports.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Models
{
    public class DataModel
    {
        SqlConnection conn = null;
        public DataModel()
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();
            }
            catch(SqlException)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public ResortMenuControlModel getResort(string param,ResortMenuControlModel m)
        {
            try
            {
                SqlCommand cmd;
                if(string.IsNullOrEmpty(param))
                {
                    cmd = new SqlCommand("EXEC baseResortReport", conn);
                }
                else
                {
                    cmd = new SqlCommand("EXEC baseResortReport", conn);
                }

                
                SqlDataReader dr = cmd.ExecuteReader();

                int i = 1;
                while(dr.Read())
                {
                    m.tabledata.Add(new ResortTableModel {
                        index = i,
                        customID = dr.GetValue(0).ToString(),
                        name = dr.GetValue(1).ToString(),
                        adults = Convert.ToInt32(dr.GetValue(2)),
                        children = Convert.ToInt32(dr.GetValue(3)),
                        pax = Convert.ToInt32(dr.GetValue(4))
                    });

                    m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(2));
                    m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(3));
                    m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(4));
                }
            }
            catch(Exception)
            {

            }

            return m;
        }
    }
}