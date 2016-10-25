using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstallManage.Models
{
    public class PartsModel
    {
    public PartsModel()
        {

        }
        public string partsName { get; set; }
        public int ServiceModelID { get; set; }
        public int PartsModelID { get; set; }
        public virtual ServiceModel  service { get; set; }

    }
    
}