using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace InstallManage.DAL
{
    public class intelicoInit:DropCreateDatabaseIfModelChanges<trackerContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(trackerContext context)
        {
           

            var cust = new List<Models.CustomerModel>
            {
                new Models.CustomerModel {CustomerKind="C", CustomerName="Rivers Taxi", CustomerMobile="1767-266-7777", CustomerPhone="1767-446-7788", ContactName="Alison Mathew" }
            };
            cust.ForEach(e => context.CustomerModels.Add(e));
            context.SaveChanges();

            var track = new List<Models.TrackerModel>
            {
                new Models.TrackerModel {simNumber="1767-616-6678", CustomerModelID=1, comment="This tracker is in excelent condition", status = "active", vehicleReg="TF-888", model="bb123-v"},
                new Models.TrackerModel {simNumber="1767-616-6677", CustomerModelID=1, comment="Tracker got wet and no longer works", status = "faulty", vehicleReg="TF-885", model="bb2114-x"},

            };
            track.ForEach(e => context.Tracker.Add(e));
            context.SaveChanges();

            var serv = new List<Models.ServiceModel>
            {
                new Models.ServiceModel {date= new DateTime(2016,10,05), timeIn ="8:00AM", timeOut="9:00AM", TrackerModelID=1, deviceTampering=false, wireTampering=false,batteryTesting="tested ok",voltage= 1.5, batteryType=24}
            };
            serv.ForEach(e => context.Service.Add(e));
            context.SaveChanges();

            var part = new List<Models.PartsModel>
            {
                new Models.PartsModel {partsName="Capacitor", ServiceModelID= 1 }
            };
            part.ForEach(e => context.Parts.Add(e));

        }
    }
}