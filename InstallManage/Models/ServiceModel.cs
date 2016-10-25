using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstallManage.Models
{
    public class ServiceModel
    {
        public ServiceModel()
        {
            partsReplaced = new List<PartsModel>();

        }
        public DateTime date { get; set; }
        public string timeIn { get; set; }
        public string timeOut { get; set; }
        public int TrackerModelID { get; set; }
        public bool deviceTampering { get; set; }
        public bool wireTampering { get; set; }
        public string batteryTesting { get; set; }
        public int ServiceModelID { get; set; }
        public double voltage { get; set; }
        public double batteryType { get; set; }
        public virtual ICollection<PartsModel> partsReplaced { get; set; }
        public virtual TrackerModel Tracker { get; set; }

    }
    
}