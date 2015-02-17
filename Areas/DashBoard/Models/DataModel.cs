using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using ChukkaDashB.Areas.DashBoard.Models;

namespace ChukkaDashB.Areas.DashBoard.Controllers
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
            catch(Exception ex)
            {

            }
        }

        public void summaryresort(string from,string to,resortModel m)
        {
            try
            {
                //resort
                SqlCommand cmd = new SqlCommand("exec DashSummary '"+from+"','"+to+"','resort'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m._resort = Convert.ToInt32(dr.GetValue(0));
                    m._hotel = Convert.ToInt32(dr.GetValue(1));
                    m._intlgrp = Convert.ToInt32(dr.GetValue(2));

                    m.resort_target = m._hotel + m._intlgrp + m._resort;
                }                

                dr.Close();

                //cruise
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','cruise'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.cruise_target = m.cruise_target+ Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();

                //direct
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','direct'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.direct_target = m.direct_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();


                //groups
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','groups'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.direct_target = m.direct_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public void summarycruise(string from,string to,cruiseModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','cruise'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                m.data = new List<cruisedetails>();

                while (dr.Read())
                {
                    m.data.Add(new cruisedetails {
                        name = dr.GetValue(0).ToString(),
                        pax = Convert.ToInt32(dr.GetValue(1))
                    });

                    m.cruise_target = m.cruise_target+ Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();

                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','resort'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.resort_target = Convert.ToInt32(dr.GetValue(0)) + Convert.ToInt32(dr.GetValue(1)) + Convert.ToInt32(dr.GetValue(2));
                }

                dr.Close();

                //resort
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','resort'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.resort_target = m.resort_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();

                //direct
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','direct'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.direct_target = m.direct_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();


                //groups
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','groups'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.direct_target = m.direct_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public void summarydirect(string from ,string to,directModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec DashSummary '"+from+"','"+to+"','direct'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.walkin = Convert.ToInt32(dr.GetValue(0));
                    m.website = Convert.ToInt32(dr.GetValue(1));
                   

                    m.direct_target = m.walkin + m.website;
                }                

                dr.Close();
             
                //resort
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','resort'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.resort_target = m.resort_target+ Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();


                //cruise
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','cruise'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.cruise_target = m.cruise_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();

                //direct
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','direct'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.direct_target = m.direct_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();


                //groups
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','groups'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.direct_target = m.direct_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public void summarygroup(string from,string to,groupsModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','groups'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.local = Convert.ToInt32(dr.GetValue(0));
                    m.national = Convert.ToInt32(dr.GetValue(1));


                    m.direct_target = m.local + m.national;
                }

                dr.Close();

                //resort
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','resort'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.resort_target = m.resort_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();


                //cruise
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','cruise'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.cruise_target = m.cruise_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();

                //direct
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','direct'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.direct_target = m.direct_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();


                //groups
                cmd = new SqlCommand("exec DashSummary '" + from + "','" + to + "','groups'", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    m.direct_target = m.direct_target + Convert.ToInt32(dr.GetValue(1));
                }

                dr.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public void summarysales(string from,string to,SalesModel m)
        {

        }
    }
}