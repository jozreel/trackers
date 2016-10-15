using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstallManage.Models
{
    public class TrackerModel
    {
        public TrackerModel()
        {
            //this.Fields = new HashSet<Field>();
        }

      
        public string vehicleReg { get; set; }
        
        public string simNumber { get; set; }
        public string status { get; set; }
        public string comment { get; set; }
        public int TrackerModelID { get; set; }
        public int CustomerModelID { get; set; }
        public virtual CustomerModel Customer { get; set; }
    }
}