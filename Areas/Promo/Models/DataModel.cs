using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.Promo.Models
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

        public void resort(PageModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec spPromocode 'resort'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                m.pagedata = new Dictionary<string,List<TableScafoiding>>();
                m.pagedata.Add("dmc", new List<TableScafoiding>());
                m.pagedata.Add("htl", new List<TableScafoiding>());
                m.pagedata.Add("itl", new List<TableScafoiding>());

                int dmc = 1;
                int htl = 1;
                int itl = 1;

                while(dr.Read())
                {
                    switch(dr.GetValue(3).ToString())
                    {
                        case "DMC":
                            {
                                m.pagedata["dmc"].Add(new TableScafoiding
                                {
                                    CustomerID = dr.GetValue(0).ToString(),
                                    Name = dr.GetValue(1).ToString(),
                                    promocode = dr.GetValue(2).ToString() ,
                                    index = dmc++,
                                    promoCount = Convert.ToInt16(dr.GetValue(4))
                                });
                                break;
                            }
                        case "HTL":
                            {
                                m.pagedata["htl"].Add(new TableScafoiding
                                {
                                    CustomerID = dr.GetValue(0).ToString(),
                                    Name = dr.GetValue(1).ToString(),
                                    promocode = dr.GetValue(2).ToString(),
                                    index = htl++,
                                    promoCount = Convert.ToInt16(dr.GetValue(4))
                                });
                                break;
                            }
                        case "ITL":
                            {
                                m.pagedata["itl"].Add(new TableScafoiding
                                {
                                    CustomerID = dr.GetValue(0).ToString(),
                                    Name = dr.GetValue(1).ToString(),
                                    promocode = dr.GetValue(2).ToString(),
                                    index = itl++,
                                    promoCount = Convert.ToInt16(dr.GetValue(4))
                                });
                                break;
                            }
                        default: break;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void cruise(PageModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec spPromocode 'cruise'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                m.pagedata = new Dictionary<string, List<TableScafoiding>>();
                m.pagedata.Add("cruise", new List<TableScafoiding>());
                int num = 1;
                while (dr.Read())
                {
                    m.pagedata["cruise"].Add(new TableScafoiding {
                        CustomerID = dr.GetValue(0).ToString(),
                        Name = dr.GetValue(1).ToString(),
                        promocode = dr.GetValue(2).ToString(),
                        index = num++,
                        promoCount = Convert.ToInt16(dr.GetValue(4))
                    });
                }
            }
            catch(Exception ex)
            {

            }
        }

        public void groups(PageModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec spPromocode 'groups'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                m.pagedata = new Dictionary<string, List<TableScafoiding>>();
                m.pagedata.Add("local", new List<TableScafoiding>());
                m.pagedata.Add("itlgrp", new List<TableScafoiding>());
                int loc = 1;
                int intl = 1;

                while (dr.Read())
                {
                    switch (dr.GetValue(3).ToString())
                    {
                        case "local":
                            {
                                m.pagedata["local"].Add(new TableScafoiding
                                {
                                    CustomerID = dr.GetValue(0).ToString(),
                                    Name = dr.GetValue(1).ToString(),
                                    promocode = dr.GetValue(2).ToString(),
                                    index = loc++,
                                    promoCount = Convert.ToInt16(dr.GetValue(4))
                                });
                                break;
                            }
                        case "itlgrp":
                            {
                                m.pagedata["itlgrp"].Add(new TableScafoiding
                                {
                                    CustomerID = dr.GetValue(0).ToString(),
                                    Name = dr.GetValue(1).ToString(),
                                    promocode = dr.GetValue(2).ToString(),
                                    index = intl++,
                                    promoCount = Convert.ToInt16(dr.GetValue(4))
                                });
                                break;
                            }
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        
        }

        public void direct(PageModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec spPromocode 'direct'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                m.pagedata = new Dictionary<string, List<TableScafoiding>>();
                m.pagedata.Add("walk", new List<TableScafoiding>());
                m.pagedata.Add("website", new List<TableScafoiding>());

                int walk = 1;
                int web = 1;

                while (dr.Read())
                {
                    switch (dr.GetValue(3).ToString())
                    {
                        case "walkin":
                            {
                                m.pagedata["walk"].Add(new TableScafoiding
                                {
                                    CustomerID = dr.GetValue(0).ToString(),
                                    Name = dr.GetValue(1).ToString(),
                                    promocode = dr.GetValue(2).ToString(),
                                    index = walk++,
                                    promoCount = Convert.ToInt16(dr.GetValue(4))
                                });
                                break;
                            }
                        case "website":
                            {
                                m.pagedata["website"].Add(new TableScafoiding
                                {
                                    CustomerID = dr.GetValue(0).ToString(),
                                    Name = dr.GetValue(1).ToString(),
                                    promocode = dr.GetValue(2).ToString(),
                                    index = web++,
                                    promoCount = Convert.ToInt16(dr.GetValue(4))
                                });
                                break;
                            }
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void sales(PageModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec spPromocode 'sales'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                m.pagedata = new Dictionary<string, List<TableScafoiding>>();
                m.pagedata.Add("sales", new List<TableScafoiding>());
                int num = 1;

                while (dr.Read())
                {
                    m.pagedata["sales"].Add(new TableScafoiding
                    {
                        index = num++,
                        CustomerID = "",
                        Name = dr.GetValue(0).ToString(),
                        promoCount = Convert.ToInt32(dr.GetValue(1))
                    });
                }
                dr.Close();

            }
            catch(Exception ex)
            {

            }
        }

        public void promos(PromoListModel m,string name)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec SalesDetailpromo '"+name+"'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                m.codeList = new List<string>();

                while(dr.Read())
                {
                    m.codeList.Add(dr.GetValue(0).ToString());
                }

                dr.Close();
            }
            catch(Exception ex)
            {

            }
        }

        public void getPromos(PromoListModel m,string code)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec PromoCodesp '"+code+"'", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                m.codeList = new List<string>();

                while (dr.Read())
                {
                    m.codeList.Add(dr.GetValue(0).ToString());
                }

                dr.Close();
            }
            catch(Exception ex)
            {

            }
        }

        public void unknown(PageModel m)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("exec spPromocode 'unknown'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                m.pagedata = new Dictionary<string, List<TableScafoiding>>();
                m.pagedata["unknown"] = new List<TableScafoiding>();

                int num = 1;

                while(dr.Read())
                {
                    m.pagedata["unknown"].Add(new TableScafoiding { 
                        index = num++,
                        Name = dr.GetValue(0).ToString()
                    });
                }

                dr.Close();
            }
            catch(Exception ex)
            {

            }
        }
        
    }
}