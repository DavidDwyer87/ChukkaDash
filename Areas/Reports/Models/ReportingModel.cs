using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace ChukkaDashB.Areas.Reports.Models
{
    public class ReportingModel
    {
        SqlConnection conn = null;
        List<string> names = new List<string>();

        public static ReportingModel instance = null;
        public DataTable celldata = null;
        public ReportingModel()
        {
            try
            {
                instance = this;

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();
            }
            catch(Exception ex)
            {

            }
        }

        public ResortMenuControlModel genericResort(ResortMenuControlModel m,string sp,string from,string to,string filter,string spec)
        {
            try
            {  
                SqlCommand cmd =null;

                string list = spec;

                if (spec.Contains("Hotel"))
                   list = list.Replace("Hotel", "htl");
                if (spec.Contains("International tour group"))
                    list = list.Replace("International tour group", "itl");


                if(sp == "baseResortReport")
                    cmd = new SqlCommand("exec " + sp+" '"+from+"','"+to+"','"+filter+"','"+list+"'", conn);
                else if(sp == "TourPerformance")
                    cmd = new SqlCommand("exec " + sp + "'" + from + "','" + to + "','" + filter + "','"+list+"'", conn);
                else if(sp=="PaxByLocation")
                    cmd = new SqlCommand("exec " + sp + "'" + from + "','" + to + "','" + filter + "','"+list+"'", conn);
                else if (sp == "cruisePort")
                {
                     StringBuilder sb = new StringBuilder();
                    SqlCommand pcmd = new SqlCommand("EXEC ReportOptionsp 'port',''", conn);
                    SqlDataReader dr2 = pcmd.ExecuteReader();
                   
                    List<string> lis = new List<string>();
                                
                    while(dr2.Read())
                    {
                        string[] ends = dr2.GetValue(0).ToString().Replace("'", "").Split(' ');
                        if (!lis.Contains(ends[1]))
                        {
                            sb.Append(ends[1] + ",");
                            lis.Add(ends[1]);
                        }
                        
                    }
                  
                    lis.Clear();
                    dr2.Close();
                    if(string.IsNullOrEmpty(list))
                        cmd = new System.Data.SqlClient.SqlCommand("EXEC cruisePort '" + from + "','" + to + "','" + sb.ToString() + "'", conn);
                    else
                        cmd = new System.Data.SqlClient.SqlCommand("EXEC cruisePort '" + from + "','" + to + "','" + list + "'", conn);
                }

                SqlDataReader dr = cmd.ExecuteReader();
                m.tabledata = new List<ResortTableModel>();
                m.footer = new TablefooterModel();
                int num = 1;

                while(dr.Read())
                {                   
                    if (
                        filter == "walkin" || filter == "website" || filter == "local" || filter == "itlgrp" || filter == "direct" ||
                        filter == "groups" || filter == "salesrep" || filter == "vessel")
                    {
                        walk(dr, m, num);
                    }
                    else if (sp == "baseResortReport")
                    {
                        Resort(dr, m, num);
                    }
                    else if (sp == "TourPerformance")
                    {
                        Perform(dr, m, num);
                    }
                    else if (sp == "PaxByLocation")
                    {
                        location(dr, m, num);
                    }
                    else if (sp == "cruisePort")
                    {
                        port(dr, m, num);
                    }
                    
                    
                    num++;
                }

                names.Clear();

                dr.Close();                
                conn.Close();
            }
            catch(Exception ex)
            {

            }

            return m;
        }       

        public ResortMenuControlModel otherReports(ResortMenuControlModel m,string sp,string from,string to,string mode)
        {
            try
            {
                SqlCommand cmd = null;
                if(!string.IsNullOrEmpty(mode))
                    cmd = new SqlCommand("exec " + sp + " '" + from + "','" + to + "','"+mode+"'", conn);    
                else if(sp == "HotelReport")
                    cmd = new SqlCommand("exec " + sp + " '" + from + "','" + to + "','" + mode + "'", conn);    
                else
                    cmd = new SqlCommand("exec " + sp + " '" + from + "','" + to + "'", conn);            
                 
                
                SqlDataReader dr = cmd.ExecuteReader();
                m.tabledata = new List<ResortTableModel>();
                m.footer = new TablefooterModel();
                int num =1;

                while(dr.Read())
                {
                    switch (sp)
                    {
                        case "HotelReport":
                            {
                                Hotel(dr, m, num);
                                break;
                            }                    
                        case "ComplimentoryReport":
                            {
                                comp(dr, m, num);
                                break;
                            }
                        case "PendingReport":
                            {
                                pending(dr, m, num);
                                break;
                            }
                        case "cancelReport":
                            {
                                pending(dr, m, num);
                                break;
                            }
                        case "nopromoReport":
                            {
                                pending(dr, m, num);
                                break;
                            }
                        default: break;
                    }
                    num++;
                }
                
                dr.Close();
            }
            catch(Exception ex)
            {

            }

            return m;

        }
       
        /// <summary>
        /// method to to get line transactions
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="name"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        public DetailListModel detail(string sp,string name,string from,string to,string channel)
        {
            DetailListModel dm = new DetailListModel();
            SqlCommand cmd = null;            
                 
            if(sp == "TourPerformanceDetails")
                cmd = new SqlCommand("exec " + sp + " '" + from + "','" + to + "','" + name + "','"+channel+"'", conn);
            else
                cmd = new SqlCommand("exec " + sp + " '" + from + "','" + to + "','" + name + "'", conn);

            SqlDataReader dr = cmd.ExecuteReader();            
            dm.details = new List<DetailsModel>();

            int i = 1;
            List<string> names = new List<string>();
            

            try
            {                
                while (dr.Read())
                {
                    string adult = "";
                    string child = "";
                    string pa = "";
                    string c ="";

                    if (string.IsNullOrEmpty(dr.GetValue(2).ToString()))
                        adult = "0";
                    else
                        adult = dr.GetValue(2).ToString();

                    if (string.IsNullOrEmpty(dr.GetValue(3).ToString()))
                        child = "0";
                    else
                        child = dr.GetValue(3).ToString();

                    if (string.IsNullOrEmpty(dr.GetValue(4).ToString()))
                        pa = "0";
                    else
                        pa = dr.GetValue(4).ToString();                    

                    dm.details.Add(new DetailsModel
                    {                        
                        index = i,
                        transNum = dr.GetValue(1).ToString(),
                        date = dr.GetValue(0).ToString(),
                        adult = Convert.ToInt32(adult),
                        children = Convert.ToInt32(child),                       
                        pax = Convert.ToInt32(pa),
                        tourname = dr.GetValue(5).ToString(),
                        salerep = dr.GetValue(6).ToString(),
                        hotelname = dr.GetValue(7).ToString()
                    });

                    if(celldata !=null)
                    {
                        celldata.Rows.Add(
                        dr.GetValue(1).ToString(),
                        dr.GetValue(0).ToString(),
                        Convert.ToInt32(dr.GetValue(2)),
                        Convert.ToInt32(dr.GetValue(3)),
                        Convert.ToInt32(dr.GetValue(4)),                        
                        dr.GetValue(5).ToString(),
                        dr.GetValue(6).ToString(),
                        dr.GetValue(7).ToString()
                    );
                    }
                        
                    i++;
                }
            }
            catch(Exception ex)
            {

            }

            dr.Close();
            
            
            return dm;
        }

        public SearchBy Filter(string val,string selected)
        {
            SearchBy sb = new SearchBy();
            sb.reportfilter = new List<FilterListModel>();

            if(val.ToLower() == "all" || val.ToLower() == "rperform" || val.ToLower() == "rpax" )
            {                
                sb.reportfilter.Add(new FilterListModel { 
                    name = "DMC",
                    check =  false
                });

                sb.reportfilter.Add(new FilterListModel
                {
                    name = "Hotel",
                    check = false
                });

                sb.reportfilter.Add(new FilterListModel
                {
                    name = "International tour group",
                    check = false
                });

                foreach(FilterListModel fm in sb.reportfilter)
                {
                    if (!string.IsNullOrEmpty(selected))
                        if (selected.Contains(fm.name))
                            fm.check = true;
                }                
            }
            else if(val == "cruise")
            {
                if (!string.IsNullOrEmpty(val))
                {
                    SqlCommand cmd = new SqlCommand("EXEC ReportOptionsp '"+val+"',''", conn);
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        bool checker = false;

                        if (!string.IsNullOrEmpty(selected))
                            if (selected.Contains(dr.GetValue(0).ToString()))
                                checker = true;

                        sb.reportfilter.Add(new FilterListModel
                        {
                            name = dr.GetValue(0).ToString(),
                            check = checker
                        });
                    }

                    dr.Close();
                    conn.Close();
                }
            }
            else if (val == "port")
            {                
                SqlCommand pcmd = new SqlCommand("EXEC ReportOptionsp 'port',''", conn);
                SqlDataReader dr2 = pcmd.ExecuteReader();

                List<string> lis = new List<string>();

                while (dr2.Read())
                {
                    string[] ends = dr2.GetValue(0).ToString().Replace("'", "").Split(' ');
                    if (!lis.Contains(ends[1]))
                    {
                        
                        bool checker = false;

                        if (!string.IsNullOrEmpty(selected))
                            if (selected.Contains(ends[1]))
                                checker = true;

                        sb.reportfilter.Add(new FilterListModel
                        {
                            name = ends[1],
                            check = checker
                        });
                        lis.Add(ends[1]);
                    }

                }

                lis.Clear();
                dr2.Close();
            }
            else if(val == "vessel")
            {
                SqlCommand cmd = new SqlCommand("EXEC ReportOptionsp 'vessel','" + val + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    bool checker = false;

                    if (!string.IsNullOrEmpty(selected))
                        if (selected.Contains(dr.GetValue(0).ToString()))
                            checker = true;

                    sb.reportfilter.Add(new FilterListModel
                    {
                        name = dr.GetValue(0).ToString(),
                        check = checker
                    });
                }

                dr.Close();
                conn.Close();
            }
            if (val == "walkin" || val == "website" || val == "local" || val == "itlgrp" || val == "direct" || val == "groups" || val  == "hotel" || val == "pax")
            {
                SqlCommand cmd = new SqlCommand("EXEC ReportOptionsp '"+val+"','" + val + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    bool checker = false;

                    if (!string.IsNullOrEmpty(selected))
                        if (selected.Contains(dr.GetValue(0).ToString()))
                            checker = true;

                    sb.reportfilter.Add(new FilterListModel
                    {
                        name = dr.GetValue(0).ToString(),
                        check = checker
                    });
                }

                dr.Close();
                conn.Close();
            }           
            else
            {
                if (!string.IsNullOrEmpty(val))
                {
                    SqlCommand cmd = new SqlCommand("EXEC ReportOptionsp 'resort','" + val + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        bool checker = false;

                        if (!string.IsNullOrEmpty(selected))
                            if (selected.Contains(dr.GetValue(0).ToString()))
                                checker = true;

                        sb.reportfilter.Add(new FilterListModel
                        {
                            name = dr.GetValue(0).ToString(),
                            check = checker
                        });
                    }

                    dr.Close();
                    conn.Close();
                }
            }           

            return sb;
        }

        /// <summary>
        /// load all resorts report with data
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="m"></param>
        /// <param name="num"></param>
        void Resort(SqlDataReader dr, ResortMenuControlModel m,int num)
        {
           if (!names.Contains(dr.GetValue(1).ToString()))
           {
               string code = "";
               try
               {
                   if (!string.IsNullOrEmpty(dr.GetValue(5).ToString()))
                       code = dr.GetValue(5).ToString();
               }
               catch (Exception) { }
               
               m.tabledata.Add(new ResortTableModel
               {
                   index = num,
                   customID = dr.GetValue(0).ToString(),
                   name = dr.GetValue(1).ToString(),
                   adults = Convert.ToInt32(dr.GetValue(2)),
                   children = Convert.ToInt32(dr.GetValue(3)),
                   pax = Convert.ToInt32(dr.GetValue(4)), 
                   rep = code
               });


               m.celldata.Rows.Add(dr.GetValue(0).ToString(),
                   dr.GetValue(1).ToString(),
                        Convert.ToInt32(dr.GetValue(2)),
                        Convert.ToInt32(dr.GetValue(3)),
                        Convert.ToInt32(dr.GetValue(4)));

               names.Add(dr.GetValue(1).ToString());
           }
           else
           {
               var query = m.tabledata.FirstOrDefault(n => n.name == dr.GetValue(1).ToString());
               query.adults =query.adults+ Convert.ToInt32(dr.GetValue(2));
               query.children = query.children + Convert.ToInt32(dr.GetValue(3));
               query.pax = query.pax +  Convert.ToInt32(dr.GetValue(4));
           }

            m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(2));
            m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(3));
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(4));
        }

        /// <summary>
        /// Load all tourperformance with data
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="m"></param>
        /// <param name="num"></param>
        void Perform(SqlDataReader dr, ResortMenuControlModel m,int num)
        {
            m.tabledata.Add(new ResortTableModel
            {
                index = num,                
                name = dr.GetValue(0).ToString(),
                adults = Convert.ToInt32(dr.GetValue(1)),
                children = Convert.ToInt32(dr.GetValue(2)),                
                pax = Convert.ToInt32(dr.GetValue(3))
            });

            m.celldata.Rows.Add(
                     dr.GetValue(0).ToString(),
                     Convert.ToInt32(dr.GetValue(1)),
                     Convert.ToInt32(dr.GetValue(2)),
                     Convert.ToInt32(dr.GetValue(3))                     
                     );

            m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(1));
            m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(2));
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(3));
        }

        void location(SqlDataReader dr, ResortMenuControlModel m,int num)
        {
            m.tabledata.Add(new ResortTableModel
            {
                index = num,
                name = dr.GetValue(0).ToString(),
                adults = Convert.ToInt32(dr.GetValue(1)),
                children = Convert.ToInt32(dr.GetValue(2)),               
                pax = Convert.ToInt32(dr.GetValue(3))
            });

            m.celldata.Rows.Add(
                     dr.GetValue(0).ToString(),
                     Convert.ToInt32(dr.GetValue(1)),
                     Convert.ToInt32(dr.GetValue(2)),
                     Convert.ToInt32(dr.GetValue(3))                    
                     );

            m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(1));
            m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(2));
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(3));
        }

        void port(SqlDataReader dr, ResortMenuControlModel m, int num)
        {
            m.tabledata.Add(new ResortTableModel
            {
                index = num,                
                name = dr.GetValue(0).ToString(),
                adults = Convert.ToInt32(dr.GetValue(1)),
                children = Convert.ToInt32(dr.GetValue(2)),
                pax = Convert.ToInt32(dr.GetValue(3))
            });


            m.celldata.Rows.Add(
                     dr.GetValue(0).ToString(),                
                     Convert.ToInt32(dr.GetValue(1)),
                     Convert.ToInt32(dr.GetValue(2)),
                     Convert.ToInt32(dr.GetValue(3)));

            m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(1));
            m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(2));
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(3));
        }

        void Hotel(SqlDataReader dr, ResortMenuControlModel m, int num)
        {
            m.tabledata.Add(new ResortTableModel
            {
                index = num,
                customID = dr.GetValue(0).ToString(),
                name = dr.GetValue(1).ToString(),
                adults = Convert.ToInt32(dr.GetValue(2)),
                children = Convert.ToInt32(dr.GetValue(3)),
                pax = Convert.ToInt32(dr.GetValue(4))
            });

            m.celldata.Rows.Add(
                     dr.GetValue(0).ToString(),
                     dr.GetValue(1).ToString(),
                     Convert.ToInt32(dr.GetValue(2)),
                     Convert.ToInt32(dr.GetValue(3)),
                     Convert.ToInt32(dr.GetValue(4)));

            m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(2));
            m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(3));
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(4));
        }

        void pax(SqlDataReader dr, ResortMenuControlModel m, int num)
        {
            m.tabledata.Add(new ResortTableModel
            {
                index = num,
                customID = dr.GetValue(0).ToString(),
                name = dr.GetValue(1).ToString(),
                adults = Convert.ToInt32(dr.GetValue(2)),
                children = Convert.ToInt32(dr.GetValue(3)),
                pax = Convert.ToInt32(dr.GetValue(4))
            });

            m.celldata.Rows.Add(
                     dr.GetValue(0).ToString(),
                     Convert.ToInt32(dr.GetValue(2)),
                     Convert.ToInt32(dr.GetValue(3)),
                     Convert.ToInt32(dr.GetValue(4)));

            m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(2));
            m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(3));
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(4));
        }

        void comp(SqlDataReader dr, ResortMenuControlModel m, int num)
        {
            m.tabledata.Add(new ResortTableModel
            {
                index = num,
                customID = dr.GetValue(0).ToString(),            
                pax = Convert.ToInt32(dr.GetValue(1)),
                name = dr.GetValue(2).ToString(),
                rep = dr.GetValue(3).ToString()
            });

            m.celldata.Rows.Add(
                     dr.GetValue(0).ToString(),
                     dr.GetValue(2).ToString(),
                     dr.GetValue(3).ToString(),
                     Convert.ToInt32(dr.GetValue(1)));

            
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(1));
        }

        void pending(SqlDataReader dr, ResortMenuControlModel m, int num)
        {
            m.tabledata.Add(new ResortTableModel
            {
                index = num,
                customID = dr.GetValue(0).ToString(),                
                adults = Convert.ToInt32(dr.GetValue(1)),
                children = Convert.ToInt32(dr.GetValue(2)),
                pax = Convert.ToInt32(dr.GetValue(3))
            });

            m.celldata.Rows.Add(
                     dr.GetValue(0).ToString(),
                     Convert.ToInt32(dr.GetValue(1)),
                     Convert.ToInt32(dr.GetValue(2)),
                     Convert.ToInt32(dr.GetValue(3)));

            m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(1));
            m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(2));
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(3));
        }       

        void walk(SqlDataReader dr, ResortMenuControlModel m, int num)
        {
            m.tabledata.Add(new ResortTableModel
            {
                index = num,
                name = dr.GetValue(0).ToString(),
                adults = Convert.ToInt32(dr.GetValue(1)),
                children = Convert.ToInt32(dr.GetValue(2)),
                pax = Convert.ToInt32(dr.GetValue(3))
            });

            m.celldata.Rows.Add(
                     dr.GetValue(0).ToString(),
                     Convert.ToInt32(dr.GetValue(1)),
                     Convert.ToInt32(dr.GetValue(2)),
                     Convert.ToInt32(dr.GetValue(3)));

            m.footer.total_adult = m.footer.total_adult + Convert.ToInt32(dr.GetValue(1));
            m.footer.total_children = m.footer.total_children + Convert.ToInt32(dr.GetValue(2));
            m.footer.total_pax = m.footer.total_pax + Convert.ToInt32(dr.GetValue(3));
        }       
    }
}