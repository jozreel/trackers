using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InstallManage.DAL
{
    public class trackerContext:DbContext
    {
        
            public trackerContext() : base("trackerappconn")
            {
                base.Configuration.ProxyCreationEnabled = false;
                Database.SetInitializer<trackerContext>(new CreateDatabaseIfNotExists<trackerContext>());

        }
        public DbSet<Models.TrackerModel> Tracker { get; set; }

        public System.Data.Entity.DbSet<InstallManage.Models.CustomerModel> CustomerModels { get; set; }
    }
}