using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstallManage.Models
{
    public class CustomerModel
    {
        public CustomerModel()
        {
            Trackers = new List<TrackerModel>();
        }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAdressSt { get; set; }
        public string CustomerAddressTown { get; set; }
        public string CustomerAddressCountry { get; set;}
        public int CustomerModelID { get; set; }
        public string CustomerKind { get; set; }
        public string ContactName { get; set; }
        public virtual ICollection<TrackerModel> Trackers { get; set;}
    }
}