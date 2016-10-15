using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace InstallManage.DAL
{
    public class intelicoInit:DropCreateDatabaseIfModelChanges<trackerContext>
    {
        protected override void Seed(trackerContext context)
        {
           

            var cust = new List<Models.CustomerModel>
            {
                new Models.CustomerModel {CustomerKind="C", CustomerName="Rivers Taxi", CustomerMobile="1767-266-7777", CustomerPhone="1767-446-7788" }
            };
            cust.ForEach(e => context.CustomerModels.Add(e));
            context.SaveChanges();

            var track = new List<Models.TrackerModel>
            {
                new Models.TrackerModel {simNumber="1767-616-6678", CustomerModelID=1, comment="This tracker is in excelent condition", status = "active", vehicleReg="TF-888"},
                new Models.TrackerModel {simNumber="1767-616-6677", CustomerModelID=1, comment="Tracker got wet and no longer works", status = "faulty", vehicleReg="TF-885"},

            };
            track.ForEach(e => context.Tracker.Add(e));
            context.SaveChanges();

        }
    }
}