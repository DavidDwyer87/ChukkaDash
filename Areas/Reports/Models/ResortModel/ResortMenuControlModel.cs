using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ChukkaDashB.Areas.Reports.Models
{
    public class ResortMenuControlModel
    {
        //resort menu 
        public string Resort { get; set; }
        public string DMC { get; set; }
        public string Hotel { get; set; }
        public string Intl { get; set; }
        public string LocationPax { get; set; }
        public string Perform { get; set; }
        public string All { get; set; }

        public string cruise { get; set; }
        public string byport { get; set; }
        public string vessel { get; set; }
        public string CPerform { get; set; }
        public string CPax { get; set; }
        public string Allcruise { get; set; }

        public string sales { get; set; }
        public string salesrep { get; set; }
        public string SPerform { get; set; }
        public string SPax { get; set; }

        public string direct { get; set; }
        public string walkin { get; set; }
        public string website { get; set; }
        public string DPerform { get; set; }
        public string DPax { get; set; }
        public string Alldirect { get; set; }

        public string group { get; set; }
        public string local { get; set; }
        public string intlgroup { get; set; }
        public string GPerform { get; set; }
        public string GPax { get; set; }
        public string Allgroup { get; set; }

        public string other { get; set; }
        public string pax { get; set; }
        public string hotelr { get; set; }
        public string OPerform { get; set; }
        
        public string comp { get; set; }
        public string pending { get; set; }
        public string cancel { get; set; }
        public string nopromo { get; set; }

        //report controls
        public string datefrom { get; set; }
        public string dateto { get; set; }

        public string filterVal { get; set; }
        public string filterVals { get; set; }

        //report data
        public List<ResortTableModel> tabledata { get; set; }

        //table footer
        public TablefooterModel footer { get; set; }     

        public DataTable celldata { get; set; }

        public string selectedfilter { get; set; }        
       
        public string subtitle { get; set; }
    }
}